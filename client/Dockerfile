FROM node:lts-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm i
RUN npm i -g @angular/cli
COPY . .
RUN ng build --configuration=production
FROM nginx:latest
COPY --from=build /app/dist/client /usr/share/nginx/html
COPY ./default.conf /etc/nginx/conf.d
EXPOSE 80