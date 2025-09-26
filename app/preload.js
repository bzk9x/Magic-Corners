const { contextBridge } = require('electron');
const { exec } = require('child_process');
const path = require('path');

contextBridge.exposeInMainWorld('wallpaper', {
    getSystemWallpaper: () => {
        return new Promise((resolve, reject) => {
            const exePath = path.join(__dirname, '..', 'c#', 'getSysWall', 'bin', 'Debug', 'net9.0', '.NET.exe');
            exec(`"${exePath}"`, (error, stdout, stderr) => {
                if (error) {
                    reject(error);
                    return;
                }
                resolve(stdout.trim());
            });
        });
    }
});