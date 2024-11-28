### **Serilog-Projekt**

---

# **Serilog-Demo**
Dieses Repository enthält ein Beispielprojekt, das zeigt, wie man die Logging-Bibliothek **Serilog** in einer ASP.NET Core-Anwendung verwendet. Es gibt zwei Varianten der Implementierung:

1. **Mit `appsettings.json`**: Konfiguration von Serilog über die Konfigurationsdatei `appsettings.json`.
2. **Ohne `appsettings.json`**: Komplette Konfiguration direkt im Code.

---

## **Projektstruktur**
Das Projekt besteht aus den folgenden Hauptdateien:
- **`Program.cs`**: Hauptlogik der Anwendung und Integration von Serilog.
- **`appsettings.json`**: Konfigurationsdatei für die Variante mit externer Konfiguration.
- **Logs**: Ordner, in dem die generierten Logdateien gespeichert werden.

---

## **Inhalt**
1. **Mit `appsettings.json`**  
   In dieser Variante wird Serilog durch die Einstellungen in der Datei `appsettings.json` konfiguriert.  
   Vorteile:
   - Zentralisierte Konfiguration.
   - Einfach anpassbar ohne Codeänderungen.

   **Beispiel für Logs in der Datei `appsettings.json`:**
   ```json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

2. **Ohne `appsettings.json`**  
   Hier erfolgt die gesamte Konfiguration direkt in `Program.cs`.  
   Vorteile:
   - Kein externer Konfigurationsbedarf.
   - Ideal für kleinere oder spezialisierte Projekte.

   **Beispiel für die Konfiguration in `Program.cs`:**
   ```csharp
   Log.Logger = new LoggerConfiguration()
       .WriteTo.Console()
       .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
       .CreateLogger();
   ```

---

## **Voraussetzungen**
- .NET 6.0 oder höher
- Serilog und Serilog.AspNetCore als NuGet-Pakete installiert.

---

## **Anleitung**
1. **Repository klonen:**
   ```bash
   git clone https://github.com/Nesimo05/Serilog.git
   ```
2. **Abhängigkeiten installieren:**
   Stelle sicher, dass die benötigten NuGet-Pakete installiert sind:
   ```bash
   dotnet add package Serilog.AspNetCore
   dotnet add package Serilog.Sinks.File
   ```
3. **Projekt ausführen:**
   ```bash
   dotnet run
   ```
4. **Logs prüfen:**
   - Konsole: Alle Logs werden in der Konsole ausgegeben.
   - Datei: Logs werden im Ordner `Logs` gespeichert.

---

## **Features**
- Automatische Rotation von Logdateien (täglich).
- Unterstützung für Konfiguration mit und ohne `appsettings.json`.
- Ausgabe in Konsole und Datei.

---

## **Autor**
Erstellt von [Nesimo05](https://github.com/Nesimo05).  
Dieses Projekt dient als Lernressource für die Integration und Nutzung von Serilog in ASP.NET Core.

---

**Viel Spaß beim Logging! 🚀**
