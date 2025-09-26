document.addEventListener('DOMContentLoaded', async () => {
    try {
        const wallpaperPath = await window.wallpaper.getSystemWallpaper();
        if (wallpaperPath) {
            const imgElement = document.getElementById('image-bg');
            imgElement.src = `file://${wallpaperPath}`;
            imgElement.style.width = '100%';
            imgElement.style.height = '100%';
            imgElement.style.objectFit = 'cover';
        }
    } catch (error) {
        console.error('Error getting wallpaper:', error);
    }
});
