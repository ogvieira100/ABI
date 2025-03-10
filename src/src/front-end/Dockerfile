# Use uma imagem do Node.js para compilar o Angular
FROM node:18 AS build
WORKDIR /app
RUN npm cache clean --force
COPY . .
RUN npm install
RUN npm run build --development

# Use Nginx para servir o app Angular
FROM nginx:latest
COPY --from=build /app/dist/developer-evaluation/browser /usr/share/nginx/html
COPY /nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
