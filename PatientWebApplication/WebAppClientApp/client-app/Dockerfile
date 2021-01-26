FROM node:12-alpine as builder
WORKDIR /app
COPY package.json /app/package.json
COPY package-lock.json /app/package-lock.json
RUN npm install
RUN npm i --save-dev @types/node
COPY . /app
RUN npm run-script dev2
CMD ["npm","run-script","dev1"]