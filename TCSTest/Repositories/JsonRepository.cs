
using System.Text.Json;

namespace TCSTest.Repositories
{
    public abstract class JsonRepository<T> : IJsonRepository<T> where T : class
    {
        private readonly string _filePath;
        private readonly Func<T, Guid> _getId;
        private readonly Action<T, Guid> _setId;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };
        protected JsonRepository(string filePath, Func<T, Guid> getId, Action<T, Guid> setId)
        {
            _filePath = filePath;
            _getId = getId;
            _setId = setId;
            EnsureFileExists();
        }
        public async Task<T> AddAsync(T entity, CancellationToken ct = default)
        {
            var all = (await GetAllAsync()).ToList();
            var id = _getId(entity);
            if (id == Guid.Empty)
            {
                id = Guid.NewGuid();
                _setId(entity, id);
            }
            all.Add(entity);
            await SaveAllAsync(all, ct);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var all = (await GetAllAsync()).ToList();
            var removed = all.RemoveAll(e => _getId(e) == id) > 0;
            if (!removed) return false;
            await SaveAllAsync(all, ct);
            return true;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default)
        {
            using var stream = File.OpenRead(_filePath);
            var list = await JsonSerializer.DeserializeAsync<List<T>>(stream, _jsonOptions, ct) ?? new List<T>();
            return list;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var all = await GetAllAsync(ct);
            return all.FirstOrDefault(e => _getId(e) == id);
        }

        public async Task<T?> UpdateAsync(Guid id, T entity, CancellationToken ct = default)
        {
            var all = (await GetAllAsync(ct)).ToList();
            var idx = all.FindIndex(e => _getId(e) == id);
            if (idx < 0) return null;
            _setId(entity, id);
            all[idx] = entity;
            await SaveAllAsync(all, ct);
            return entity;
        }

        private async Task SaveAllAsync(List<T> entities, CancellationToken ct)
        {
            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, entities, _jsonOptions, ct);
        }

        private void EnsureFileExists()
        {
            var dir = Path.GetDirectoryName(_filePath)!;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!File.Exists(_filePath))
            {
                using var stream = File.Create(_filePath);
                var empty = JsonSerializer.SerializeToUtf8Bytes(new List<T>(), _jsonOptions);
                stream.Write(empty);
            }
        }
    }
}
