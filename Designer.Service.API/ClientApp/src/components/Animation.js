export const animatation = () => {
    var path = new Path.Rectangle({
        point: [75, 75],
        size: [75, 75],
        strokeColor: 'black'
    });
    
    function onFrame(event) {
        // Each frame, rotate the path by 3 degrees:
        path.rotate(3);
    }
}