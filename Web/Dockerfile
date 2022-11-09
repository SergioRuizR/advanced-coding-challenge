FROM node:lts-alpine3.15
WORKDIR /app
COPY package.json .
RUN npm install
COPY . .

EXPOSE 3000

# RUN adduser node root

# RUN chmod -R 775 /src
# RUN chown -R node:root /src

# USER node
CMD ["npm","start"]