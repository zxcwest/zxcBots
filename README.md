# ZxcBots - A Simple Twitch Bot

This repository contains the core (base) code for ZxcBots — a simple and extendable Twitch bot designed to help streamers manage their chat and automate routine tasks.

---

## 📖 Usage Guide

### 🧠 Overview

`ZxcBots` is a simple and extendable Twitch bot written in **C#**, created to help streamers manage their chat, automate common tasks, and enhance interaction with their audience.

It works either with:

- ✅ A **streamer account only**
- ✅ Or a **streamer + bot account** combo (recommended)

---

### 🔑 Required Twitch OAuth Scopes

To ensure full functionality, the bot needs the following Twitch API scopes:

- `chat:read` — read chat messages
- `chat:edit` — send chat messages
- `channel:manage:polls` / `channel:read:polls` — manage and read polls
- `channel:manage:predictions` / `channel:read:predictions` — manage and read predictions
- `channel:manage:broadcast` — update stream title/category
- `moderator:manage:banned_users` — mass-ban feature
- `moderator:read:followers` — track follower info
- `channel:read:redemptions` — read channel point redemptions
- `channel:read:subscriptions` — access subscription info
- `user:read:email` — optional, for future integrations
- `channel:manage:schedule` — manage stream schedule if needed

You’ll also need to register a Twitch Application in [Twitch Developer Console](https://dev.twitch.tv/console).

---

### 🚀 Quick Start (Precompiled .exe)

For non-developers who just want to run the bot quickly:

1. Go to the [Releases](https://github.com/zxcwest/zxcBots/releases) page or [Telegram Channel](https://t.me/twitchzxcbot)
2. Download the latest `.exe` release
3. Fill in the `config.json` file (example provided)
4. Run the `.exe`

> ⚠ You will need:
>
> - A valid OAuth token (Streamer or Moderator)
> - Twitch application client ID and secret

If you don’t know how to generate these — feel free to [contact me](https://t.me/twitchzxcbot), I’ll help.

---

### 🌐 Running on Linux / Hosting (24/7 mode)

The bot supports 24/7 operation on **Linux servers**, VPS hosting, or even Docker. Requires [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download):

```bash
git clone https://github.com/zxcwest/zxcBots.git
cd zxcBots
dotnet build
dotnet run
```

---

### 🔍 Features

Here’s what ZxcBots can do out of the box:

- 🧹 **Moderation** — ban, timeout, chat clearing
- ⚙ **Custom commands** — easily configurable
- ❌ **Mass-ban** — ban users based on keywords
- 📊 **Polls & Predictions** — directly from Twitch API
- 🧠 **Frequent word stats** — shows commonly used words
- 🌍 **Live translation** — automatically translates English chat messages to Russian
- ✨ **Extendability** — easily write your own logic with built-in wrappers

---

### 🛠 Development Notes

Want to develop your own features?

- The source code is well-commented and modular
- All major functionality is organized into wrappers or service classes
- You’re welcome to fork or extend the bot for **non-commercial use**

> Recommended IDE: **Visual Studio 2022 Community**\
> License: [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) *(non-commercial only)*

---

### 👥 Support & Contact

If you:

- Need help setting up your Twitch application
- Want to request a custom feature
- Have questions about configuration

Feel free to reach out!

- 📬 Telegram: [@twitchzxcbot](https://t.me/twitchzxcbot)
- 💌 Discord: `west.5`

---

### 📄 Licensing (Reminder)

ZxcBots is licensed under **CC BY-NC 4.0**, meaning:

- ✅ Free for personal, non-commercial use
- ❌ Not allowed to sell, resell, or include in paid products
- 🎼 Attribution required (`zxcWest_`)

The `TwitchLib` dependency is licensed under [MIT License](https://github.com/TwitchLib/TwitchLib).

---

See the LICENSE file for full terms.

---

# 🇷🇺 ZxcBots — Простой Twitch Бот

Этот репозиторий содержит основной код ZxcBots — простого и расширяемого Twitch-бота, созданного для помощи стримерам в управлении чатом и автоматизации рутинных задач.

---

## 📖 Инструкция по использованию

### 🧠 Общее

Бот написан на **C#**. Работает с:

- ✅ Только аккаунтом стримера
- ✅ Или стримером + отдельным аккаунтом бота (рекомендуется)

---

### 🔑 Требуемые права Twitch (OAuth)

Для корректной работы необходимы следующие права:

- `chat:read` — чтение сообщений
- `chat:edit` — отправка сообщений
- `channel:manage:polls` / `channel:read:polls` — управление/чтение опросов
- `channel:manage:predictions` / `channel:read:predictions` — управление/чтение прогнозов
- `channel:manage:broadcast` — смена названия/категории стрима
- `moderator:manage:banned_users` — массовая блокировка
- `moderator:read:followers` — доступ к фолловерам
- `channel:read:redemptions` — чтение вознаграждений
- `channel:read:subscriptions` — чтение информации о подписках
- `user:read:email` — (опционально)
- `channel:manage:schedule` — изменение расписания

Также потребуется зарегистрировать приложение в [Twitch Developer Console](https://dev.twitch.tv/console).

---

### 🚀 Быстрый запуск (.exe)

Если не хотите работать с исходным кодом:

1. Перейдите в [Releases](https://github.com/zxcwest/zxcBots/releases) или [Telegram](https://t.me/twitchzxcbot)
2. Скачайте `.exe`
3. Заполните `config.json`
4. Запустите `.exe`

> ⚠ Необходимо:
>
> - OAuth-токен Twitch
> - Client ID + Secret от Twitch App

Не знаете, как это сделать? Напишите — помогу.

---

### 🌐 Хостинг на Linux (режим 24/7)

Работает на Linux-серверах/VPS. Требуется [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download):

```bash
git clone https://github.com/zxcwest/zxcBots.git
cd zxcBots
dotnet build
dotnet run
```

---

### 🔍 Возможности

- 🧹 **Модерация** — бан, мут, очистка чата
- ⚙ **Кастомные команды**
- ❌ **Массовый бан** — по ключевым словам
- 📊 **Опросы и прогнозы**
- 🧠 **Статистика слов** за стрим
- 🌍 **Авто-перевод** с английского на русский
- ✨ **Гибкое расширение** — можно писать свои модули

---

### 🛠 Разработка

- Открытый и комментированный код
- Структура с обёртками и сервисами
- Используйте, дорабатывайте, но **только не в коммерческих целях**

> Рекомендую: **Visual Studio 2022 Community**

---

### 👥 Обратная связь

Если нужно:

- Помощь с приложением Twitch
- Уникальный функционал
- Поддержка или консультация

Пишите:

- 📬 Telegram: [@twitchzxcbot](https://t.me/twitchzxcbot)
- 💌 Discord: `west.5`

---

### 📄 Лицензия

Проект распространяется под **CC BY-NC 4.0**:

- ✅ Бесплатно для личного, некоммерческого использования
- ❌ Запрещена перепродажа/встраивание в платные продукты
- 🏷 Обязательное указание автора: `zxcWest_`

`TwitchLib` — лицензия MIT (см. [репозиторий TwitchLib](https://github.com/TwitchLib/TwitchLib)).

