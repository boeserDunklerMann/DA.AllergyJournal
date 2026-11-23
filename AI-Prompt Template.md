Erzeuge eine UI zur Erfassung von vier Dingen, nämlich Nase, Augen, Lunge, Haut. Dabei stelle ich mir zu jedem Item einen Schieberegler vor,
bei dem ich Werte zwischen 0 und 3 einstellen kann. Dazu hätte ich gerne den Markup-Code als XAML, damit ich die UI in eine MAUI App integrieren
kann.
------------------
# Software Development Prompt Template

## 1. Rolle & Kontext
Du bist [z. B. Senior Backend Engineer / Flutter Developer / Security Auditor].
Kontext: [Kurze Beschreibung des Projekts, Domäne, Zielgruppe]
Codebase-Reife: [Greenfield / Legacy-Modernisierung / bestehendes Team-Repo]

## 2. Aufgabe
**Ziel:** [1–2 Sätze, was am Ende funktionieren/existieren soll]
**Nicht-Ziel:** [Was explizit *nicht* Teil dieser Aufgabe ist – verhindert Scope-Creep]

## 3. Tech-Stack & Umgebung
- Sprache/Version: [z. B. Dart 3.5, Python 3.12]
- Framework: [z. B. Flutter 3.24, FastAPI, Next.js 15]
- Wichtige Libraries: [z. B. Riverpod, Dio, Pydantic v2]
- Zielplattform: [iOS/Android/Web/Linux, Node-Version, DB]
- Tooling: [Linter, Formatter, Test-Runner]

## 4. Anforderungen
### Funktional
- [ ] [Konkretes User-Verhalten / API-Endpunkt / UI-Interaktion]
- [ ] […]

### Nicht-funktional
- Performance: [z. B. <200 ms p95, offline-fähig]
- Security: [z. B. Input-Validierung, keine Secrets im Code, OWASP-Top-10 beachten]
- Accessibility: [z. B. WCAG 2.1 AA, Screenreader-Labels]
- i18n: [Sprachen, Locale-Handling]

## 5. Input / Output
**Input:** [Datenformat, Beispiel-Payload, Schema]
**Erwarteter Output:** [Datei(en), Signaturen, Response-Format]
**Rückgabestruktur des Prompts:**
1. Kurze Zusammenfassung der Lösung
2. Code (vollständig lauffähig, keine `...`-Placeholder)
3. Tests
4. Setup-/Run-Anleitung
5. Offene Punkte / Trade-offs

## 6. Beispiele
### Input-Beispiel
```json
{ … }
```
### Erwartetes Verhalten
```
…
```

## 7. Edge Cases & Fehlerbehandlung
- [z. B. leere Liste, Netzwerk-Timeout, ungültiges Token]
- Fehlerpolicy: [Exceptions vs. Result-Type, Logging-Level]

## 8. Coding-Standards
- Style: [z. B. `dart format`, `ruff`, Team-Linter-Config]
- Namenskonventionen: [Sprache Englisch, camelCase/snake_case]
- Kommentare: nur wo das *Warum* nicht offensichtlich ist
- Keine toten Abhängigkeiten oder auskommentierten Code-Blöcke

## 9. Tests
- Framework: [z. B. `pytest`, `flutter_test`]
- Coverage-Erwartung: [z. B. Kernlogik ≥ 80 %]
- Mindestens: 1 Happy Path, 1 Edge Case, 1 Fehlerpfad pro öffentlicher Funktion

## 10. Definition of Done
- [ ] Code kompiliert / läuft ohne Warnings
- [ ] Alle Tests grün
- [ ] Linter/Formatter sauber
- [ ] README/Docstrings aktualisiert
- [ ] Keine hardcodierten Secrets/URLs
- [ ] Manuell verifiziertes Beispiel im PR-Description

## 11. Constraints & Hinweise an das Modell
- Wenn Anforderungen unklar sind: **frage nach**, statt zu raten.
- Bei mehreren gangbaren Ansätzen: kurz Optionen skizzieren, dann Empfehlung.
- Keine Bibliotheken einführen, die nicht im Stack stehen, ohne das explizit zu markieren.
- Antwort-Sprache: [Deutsch/Englisch]