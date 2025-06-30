# TCS Technical Test
# 🎬 TV Show Catalog & Schedule API

This project is a .NET Core Web API that simulates a TV/Moviwa catalog and scheduling system, using clean, modular architecture and **JSON files as the data store** (no database required).

It’s designed as a technical test to demonstrate real-world API and C# skills including:

- JSON-based data modeling
- RESTful API design
- In-memory file persistence
- Clean architecture (controllers, services, repositories)
- CRUD operations across multiple entities
- Optional enhancements like search, filtering, and metadata

---

## 🧱 Features

### 🎞️ Content Catalog
- Add / update / delete movies and shows
- Store metadata like title, genre, type, duration, rating, etc.

### 📺 Channel Manager
- Manage channels like "Fox Movies", "Fox Showcase", etc.
- Each channel stores name, provider, language, and region

### 🕐 Program Scheduler
- Schedule shows or movies to air on specific channels
- Filter schedule by channel, date, or “currently airing”

---

## 📂 JSON-Based Storage

This project uses three flat JSON files as the datastore:

- `channels.json` — Channels details
- `content_catalog.json` — Movies and shows metadata
- `channel_schedule.json` — Airing schedule with start/end time

All entities use `Guid` IDs and can be easily extended.

---

## 🔧 Tech Stack

- .NET Core 8 Web API
- C# 12
- System.Text.Json for file serialization
- Minimal API or Controller-based architecture
---

## 🚀 How to Run

1. Clone the repo
2. Build the project
3. Run the API (`dotnet run`)
4. Use Swagger or Postman to test endpoints like:
   - `GET /api/content`
   - `GET /api/schedule/now`
   - `POST /api/channels`
