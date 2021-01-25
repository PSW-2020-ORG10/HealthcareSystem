const express = require('express');
const jsonServer = require('json-server');
const router = express.Router();
const server = jsonServer.create();
const mainRoute = jsonServer.router('db.json');
const middlewares = jsonServer.defaults({ noCors: false });
const port = process.env.PORT || 54689;

router.use('/api', mainRoute)
server.use(middlewares);
server.use(router);

server.listen(port);