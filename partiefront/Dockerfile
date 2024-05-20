# Utilisez l'image de node pour construire l'application
FROM node:14 AS build-env
WORKDIR /app

# Copiez les fichiers nécessaires et installez les dépendances
COPY package*.json ./
RUN npm install

# Copiez le reste des fichiers de l'application
COPY . .

# Construisez l'application
RUN npm run build

# Servez l'application avec Nginx
FROM nginx:alpine
COPY --from=build-env /app/dist /usr/share/nginx/html