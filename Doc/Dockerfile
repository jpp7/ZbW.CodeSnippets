# Verwende ein leichtgewichtiges NGINX-Image
FROM nginx:alpine

# Lösche den Default-HTML-Inhalt
RUN rm -rf /usr/share/nginx/html/*

# Kopiere deine generierten HTML-Dateien ins Webverzeichnis
COPY output/html /usr/share/nginx/html

# Optional: Port dokumentieren
EXPOSE 80

# NGINX startet automatisch als CMD
