# KVP-Tool (ASP.NET Core 9 MVC)

Ein internes **Kaizen/KVP-Tool** zur Unterstützung des **Kontinuierlichen Verbesserungsprozesses**.  
Ziel: Probleme erfassen, analysieren und Maßnahmen nachvollziehbar steuern.

## ✨ Features (MVP)
- **F001 – Problemerfassung**: strukturierte Erfassung von Prozessproblemen
- **F002 – KPI-Erfassung**: Current/Future State, Vorher-Nachher-Vergleich
- **F003 – Problemanalyse**: Methoden wie Ishikawa, 5-Why, Prozessmapping
- **F004 – Maßnahmenmanagement**: Planung, Fristen, Verantwortlichkeiten
- **F005 – Prozess-Dashboard**: KPIs und Fortschritte visuell vergleichen
- **F006 – Dokumentenmanagement**: Uploads und Versionierung

Optionale Features:
- **F007 – KI-gestützte Vorschläge**  
- **F008 – Mehrsprachigkeit (DE/EN)**

## 🏗️ Architektur
- **.NET 9 / ASP.NET Core MVC**
- **Clean Architecture**: Domain, Application, Infrastructure, Web
- **xUnit Tests**: UnitTests + IntegrationTests
- **Custom Portfolio License** (Code darf betrachtet und getestet, aber nicht produktiv genutzt werden)

## 🚀 Quickstart
### Voraussetzungen
- Visual Studio 2022 (aktuellste Version)
- .NET 9 SDK

### Starten
```bash
# Build
dotnet build

# Tests
dotnet test

# Starten (lokal, Debug)
dotnet run --project src/KvpTool.Web
