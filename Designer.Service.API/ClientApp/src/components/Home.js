import React from 'react';
import clsx from 'clsx';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import InputAdornment from '@material-ui/core/InputAdornment';
import FormControl from '@material-ui/core/FormControl';
import axios from "axios";
import Canvas from './Canvas'

export const Home = () => {
  const useStyles = makeStyles((theme) => ({
    root: {
      display: 'flex',
      flexWrap: 'wrap',
    },
    margin: {
      margin: theme.spacing(2),
    },
    withoutLabel: {
      marginTop: theme.spacing(3),
    },
    textField: {
      width: '25ch',
      margin: theme.spacing(1),
    },
  }));
  
  const api = axios.create({
    baseURL: process.env.ENDPOINT,
  });
  
  const [containerWidth, setContainerWidth] = React.useState(500);
  const [containerLength, setContainerLength] = React.useState(500);
  const [tableWidth, setTableWidth] = React.useState(200);
  const [tableLength, setTableLength] = React.useState(100);
  const [chairWidth, setChairWidth] = React.useState(40);
  const [chairLength, setChairLength] = React.useState(30);
  const [container, setContainer] = React.useState({ width: 0, length: 0, point: { x: 0, y: 0 } });
  const [table, setTable] = React.useState({ width: 0, length: 0, point: { x: 0, y: 0 } });
  const [chair, setChair] = React.useState({ width: 0, length: 0, point: { x: 0, y: 0 } });
  const [accuracy, setAccuracy] = React.useState(10);
  const [requiredSpace, setRequiredSpace] = React.useState(10);


  function* iterateOverArray(arr) {
    var i = 0;
    while (i < arr.length) {
      yield arr[i++];
    }
  }
  const calculate = () => {
    console.log(process.env.ENDPOINT);
    setContainer({
      width: containerWidth,
      length: containerLength,
      point: { x: 0, y: 0 }
    })
    debugger
    console.log(process.env)
    
    api.post('Generate', {
      "container": {
        "width": containerWidth,
        "length": containerLength
      },
      "table": {
        "width": tableWidth,
        "length": tableLength
      },
      "chair": {
        "width": chairWidth,
        "length": chairLength,
        "requiredSpace": requiredSpace
      },
      "accuracy": accuracy
    }
    )
      .then(response => {
        animate(0, response.data.coordinates)
      });
  }

  const animate = (i, coordinates) => {
    if (i < coordinates.length)
      setTable({
        width: tableWidth,
        length: tableLength,
        point: { x: coordinates[i].key.x, y: coordinates[i].key.y }
      })
    var chairGenerator = iterateOverArray(coordinates[i].value);
    var interval = setInterval(() => {
      var nxt = chairGenerator.next();
      if (!nxt || nxt.done) {
        clearTimeout(interval);
        animate(++i, coordinates)
      }
      else {
        setChair({
          width: chairWidth,
          length: chairLength,
          point: { x: nxt.value.x, y: nxt.value.y }
        })
      }
    }, 50);
  }

  const classes = useStyles();


  return (<>
    <Canvas container={container} table={table} chair={chair} />
    <div className={classes.root}>
      <FormControl className={clsx(classes.margin, classes.withoutLabel, classes.textField)}>
        <TextField
          label="Container Width"
          id="ContainerWidth"
          value={containerWidth}
          onChange={(e) => setContainerWidth(e.target.value)}
          className={clsx(classes.margin, classes.textField)}
          InputProps={{
            startAdornment: <InputAdornment position="start">cm</InputAdornment>,
          }}
          variant="outlined"
        />
        <TextField
          label="Container Length"
          id="ContainerLength"
          value={containerLength}
          onChange={(e) => setContainerLength(e.target.value)}
          className={clsx(classes.margin, classes.textField)}
          InputProps={{
            startAdornment: <InputAdornment position="start">cm</InputAdornment>,
          }}
          variant="outlined"
        />
      </FormControl>

      <FormControl className={clsx(classes.margin, classes.withoutLabel, classes.textField)}>
        <TextField
          label="Table Width"
          id="TableWidth"
          value={tableWidth}
          onChange={(e) => setTableWidth(e.target.value)}
          className={clsx(classes.margin, classes.textField)}
          InputProps={{
            startAdornment: <InputAdornment position="start">cm</InputAdornment>,
          }}
          variant="outlined"
        />
        <TextField
          label="Table Length"
          id="TableLength"
          value={tableLength}
          onChange={(e) => setTableLength(e.target.value)}
          className={clsx(classes.margin, classes.textField)}
          InputProps={{
            startAdornment: <InputAdornment position="start">cm</InputAdornment>,
          }}
          variant="outlined"
        />
      </FormControl>

      <FormControl className={clsx(classes.margin, classes.withoutLabel, classes.textField)}>
        <TextField
          label="Chair Width"
          id="ChairWidth"
          value={chairWidth}
          onChange={(e) => setChairWidth(e.target.value)}
          className={clsx(classes.margin, classes.textField)}
          InputProps={{
            startAdornment: <InputAdornment position="start">cm</InputAdornment>,
          }}
          variant="outlined"
        />
        <TextField
          label="Chair Length"
          id="ChairLength"
          value={chairLength}
          onChange={(e) => setChairLength(e.target.value)}
          className={clsx(classes.margin, classes.textField)}
          InputProps={{
            startAdornment: <InputAdornment position="start">cm</InputAdornment>,
          }}
          variant="outlined"
        />
      </FormControl>

      <FormControl className={clsx(classes.margin, classes.withoutLabel, classes.textField)}>
        <TextField
          label="Accuracy"
          id="accuracy"
          value={accuracy}
          onChange={(e) => setAccuracy(e.target.value)}
          className={clsx(classes.margin, classes.textField)}
          InputProps={{
            startAdornment: <InputAdornment position="start">cm</InputAdornment>,
          }}
          variant="outlined"
        />
        <TextField
          label="Required Space"
          id="requiredSpace"
          value={requiredSpace}
          onChange={(e) => setRequiredSpace(e.target.value)}
          className={clsx(classes.margin, classes.textField)}
          InputProps={{
            startAdornment: <InputAdornment position="start">cm</InputAdornment>,
          }}
          variant="outlined"
        />
      </FormControl>
      <Button variant="contained"
        className={clsx(classes.margin)}
        onClick={calculate}
        color="primary"
      >
        calculate
      </Button>
    </div>
  </>
  )
}
