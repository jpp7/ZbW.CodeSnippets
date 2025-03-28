# 📚 Documentation

## 🔧 Installation

Installiere die Doxygen-HTML-Dokumentationstools über [Chocolatey](https://chocolatey.org/):

```bash
choco install doxygen.install -y
choco install doxybook2 -y
```
*Code: Installation via Chocolatey*

---

## 📄 Doxygen verwenden

Erstelle die HTML-Dokumentation mit Doxygen:

```bash
doxygen Doxyfile
```
*Code: HTML-Dokumentation generieren*

---

## 🐳 Container erstellen

Baue den Docker-Container mit `docker build`:

```bash
docker build -t snippet-docs .
```
*Code: Container erstellen*

---

## ▶️ Container starten

Starte den erstellten Container mit `docker run`:

```bash
docker stop docs-server
docker rm docs-server
```
*Code: Container entfernen*

```bash
docker run -d -p 8081:80 --name docs-server snippet-docs
```
*Code: Container starten*

## 🌐 Zugriff auf die Dokumentation

Zugreife auf die Dokumentation über den Browser:
[Documentation](http://localhost:8081)
