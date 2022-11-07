FROM node:11.14.0-alpine
RUN apk upgrade -U

EXPOSE 3000

COPY . .

RUN npm install

RUN adduser node root

RUN chmod -R 775 /src
RUN chown -R node:root /src

USER node
CMD ["npm","start"]