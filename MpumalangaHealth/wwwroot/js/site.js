// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Fallback for missing MEC image or video
document.addEventListener('DOMContentLoaded', function () {
    // Check if MEC image loaded successfully
    const mecImage = document.querySelector('.mec-image');
    if (mecImage) {
        mecImage.addEventListener('error', function () {
            this.src = 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNDAwIiBoZWlnaHQ9IjMwMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj48cmVjdCB3aWR0aD0iMTAwJSIgaGVpZ2h0PSIxMDAlIiBmaWxsPSIjZjhmOGY4Ii8+PGcgdGV4dC1hbmNob3I9Im1pZGRsZSIgZm9udC1mYW1pbHk9InNhbnMtc2VyaWYiIGZvbnQtc2l6ZT0iMjQiPjx0ZXh0IHg9IjUwJSIgeT0iNDAlIiBmaWxsPSIjMDhBMDQ1IiBmb250LXdlaWdodD0iYm9sZCI+TUVDIFBvcnRyYWl0PC90ZXh0Pjx0ZXh0IHg9IjUwJSIgeT0iNTAlIiBmaWxsPSIjNjY2Ij5JbWFnZSBub3QgYXZhaWxhYmxlPC90ZXh0PjwvZz48L3N2Zz4=';
            this.alt = 'MEC Portrait - Image not available';
        });
    }

    // Check if video loaded successfully
    const video = document.querySelector('video');
    if (video) {
        video.addEventListener('error', function () {
            const videoContainer = this.closest('.video-container');
            if (videoContainer) {
                videoContainer.innerHTML = `
                    <div class="placeholder-hero text-center p-5 rounded">
                        <i class="fas fa-video fa-4x text-white mb-3"></i>
                        <h4 class="text-white">Healthcare Facilities Tour</h4>
                        <p class="text-white opacity-75">Video content coming soon</p>
                    </div>
                `;
            }
        });
    }

});