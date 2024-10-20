process.env.NODE_ENV = 'production';
process.chdir(__dirname);

const NextServer = require('next/dist/server/next-server').default;
const http = require('http');
const path = require('path');

const fs = require('fs');
const { config } = JSON.parse(fs.readFileSync('required-server-files.json'));

// Make sure commands gracefully respect termination signals (e.g. from Docker)
process.on('SIGTERM', () => process.exit(0));
process.on('SIGINT', () => process.exit(0));

let handler;

const server = http.createServer(async (req, res) => {
    try {
        await handler(req, res);
    } catch (err) {
        console.error(err);
        res.statusCode = 500;
        res.end('internal server error');
    }
});
const currentPort = parseInt(process.env.PORT, 10) || 3000;
 
server.listen(currentPort, (err) => {
    if (err) {
        console.error('Failed to start server', err);
        process.exit(1);
    }
    const addr = server.address();
    const nextServer = new NextServer({
        hostname: 'localhost',
        port: currentPort,
        dir: path.join(__dirname),
        dev: false,
        conf: config,
    });
    
    handler = nextServer.getRequestHandler();
});