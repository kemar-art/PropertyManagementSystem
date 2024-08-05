document.addEventListener("DOMContentLoaded", function () {
    const steps = Array.from(document.querySelectorAll(".steps"));
    steps.forEach(stepContainer => {
        const stepButtons = Array.from(stepContainer.querySelectorAll(".step-button"));
        const progress = stepContainer.querySelector("progress");

        const progressValue = parseInt(progress.value, 10);
        const activeStepIndex = Math.floor((progressValue / 100) * stepButtons.length);

        stepButtons.forEach((button, index) => {
            if (index < activeStepIndex) {
                button.classList.add("done");
                button.classList.remove("active");
            } else if (index === activeStepIndex) {
                button.classList.add("active");
                button.classList.remove("done");
            } else {
                button.classList.remove("active");
                button.classList.remove("done");
            }
        });
    });
});