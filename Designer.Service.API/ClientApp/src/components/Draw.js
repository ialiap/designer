import Paper from "paper";

const draw = props => {
  new Paper.Path.Rectangle({
        point: [props.container.point.x, props.container.point.y],
        size: [props.container.width, props.container.length],
        strokeColor: 'black'
    });
     new Paper.Path.Rectangle({
        point: [props.table.point.x, props.table.point.y],
        size: [props.table.width, props.table.length],
        strokeColor: 'blue'
    });
   new Paper.Path.Rectangle({
        point: [props.chair.point.x, props.chair.point.y],
        size: [props.chair.width, props.chair.length],
        strokeColor: 'red'
    });
 
    Paper.view.draw();
};

export default draw;