# TCS Technical Test
# 🎬 TV Show Catalog & Schedule API

This project is a .NET Core Web API that simulates a TV/Moviwa catalog and scheduling system, using clean, modular architecture and **JSON files as the data store** (no database required).

It’s designed as a technical test to demonstrate real-world API and C# skills including:

- JSON-based data modeling
- RESTful API design
- In-memory file persistence
- Clean architecture (controllers, services)
- CRUD operations across multiple entities

---

## 🧱 Features

### 🎞️ Content Catalog
- Add / update / delete movies and shows
- Store metadata like title, genre, type, duration, rating, etc.

### 📺 Channel Manager
- Manage channels .
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


## 🚧 Functional Requirements

### 1. Channels API
- [ ] `GET /api/channels` — List all channels
- [ ] `POST /api/channels` — Add a new channel
- [ ] `PUT /api/channels/{id}` — Update channel details
- [ ] `DELETE /api/channels/{id}` — Delete a channel

### 2. Content API (Movies / Shows)
- [ ] `GET /api/content` — List all content
- [ ] `GET /api/content/{id}` — View details of a movie or show
- [ ] `POST /api/content` — Add new content
- [ ] `PUT /api/content/{id}` — Update content
- [ ] `DELETE /api/content/{id}` — Delete content

### 3. Schedule API
- [ ] `GET /api/schedule` — View all scheduled airings
- [ ] `GET /api/schedule/channel/{channelId}` — View schedule for a specific channel
- [ ] `GET /api/schedule/now` — See what’s currently airing
- [ ] `POST /api/schedule` — Add a scheduled airing
- [ ] `PUT /api/schedule/{channelId}/{contentId}` — Update a scheduled time slot
- [ ] `DELETE /api/schedule/{channelId}/{contentId}` — Remove a scheduled airing

---

## ✅ Technical Requirements

- Use .NET 8 Web API (or .NET 6+ is acceptable)
- All data must be persisted to local JSON files (no database)
- Use clean separation: Controllers → Services → Repositories
- Use `Guid` IDs for all entities
- Keep the solution lightweight and readable

---

## ✍️ Summary

This test showcases your ability to:
- Model and manage entities using file-based storage
- Design and implement RESTful APIs
- Work with async file operations
- Structure clean, modular code

---

## 📌 Notes

- No frontend is required — focus on backend only.
- No database — data must live in flat JSON files stored in the project directory.

---


