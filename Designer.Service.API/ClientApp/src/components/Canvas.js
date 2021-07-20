import React, { useRef, useEffect } from 'react';
import Paper from 'paper';
import draw from './Draw';

const Canvas = props => {
  
  const canvasRef = useRef(null)
  useEffect(() => {
    const canvas = canvasRef.current;
    Paper.setup(canvas);
    draw(props);
  }, [props]);
  
  return <canvas ref={canvasRef} {...props} id="canvas"  style={{border: '1px dotted red',width:'100%',height:'100%'}} resize="true"/>
}

export default Canvas;