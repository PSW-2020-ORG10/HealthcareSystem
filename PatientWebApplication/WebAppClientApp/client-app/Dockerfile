# pull official base image
FROM node:13.12.0-alpine

# set working directory
WORKDIR /app
EXPOSE 3000
# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY package.json ./
COPY package-lock.json ./
RUN npm install axios --save
RUN npm install --silent
RUN npm install serve --s
RUN npm install react-scripts@3.4.1 -g --silent
RUN npm install react-toastify \
    react-transition-group \
    regenerator-runtime \
    react-stepper-horizontal \
    react-datepicker \
    react-is \
    prop-types \
    object-assign \
    loose-envify \
    js-tokens \
    follow-redirects \
    dom-helpers \
    csstype \
    clsx \
    axios

# add app
COPY . ./

# start app
CMD ["npm", "start"]