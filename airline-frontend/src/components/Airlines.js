import React from 'react';
import axios from "axios";
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import 'bootstrap/dist/css/bootstrap.css';
import { useEffect, useState } from "react";

function Airlines() {

  // const [id, setId] = useState("");
  const [name, setName] = useState("");
  const [flightNo, setFlightNo] = useState("");
  const [from, setFrom] = useState("");
  const [to, setTo] = useState("");
  const [seat, setSeat] = useState("");

  const [Airline, setAirline] = useState([]);

  useEffect(() => { getData(); });

  const getData = () => {
    axios.get("https://localhost:7044/api/Airlines")
      .then((result) => setAirline(result.data)
      );
  };

  async function save(event) {

    event.preventDefault();
    try {
      await axios.post("https://localhost:7044/api/Airlines", {
        Name: name,
        FlightNo: flightNo,
        From: from,
        To: to,
        Seat: seat
      });
      alert("Saved Successfully");
      setName("");
      setFlightNo("");
      setFrom("");
      setTo("");
      setSeat("");
      getData();
    } catch (err) {
      alert(err);
    }
  }


  return (
    <div>
      <h1>Airline Details</h1>
      <Form>
        <Form.Group>
          <Form.Label>Airline Name</Form.Label>
          <br></br>
          <input type="text" value={name} onChange={(event) => {
            setName(event.target.value);
          } } />
        </Form.Group>
        <Form.Group>
          <Form.Label>Flight No </Form.Label>
          <br></br>
          <input value={flightNo} onChange={(event) => {
            setFlightNo(event.target.value);
          } } />
        </Form.Group>

        <Form.Group>
          <Form.Label>From</Form.Label>
          <br></br>
          <input value={from} onChange={(event) => {
            setFrom(event.target.value);
          } } />
        </Form.Group>

        <Form.Group>
          <Form.Label>To</Form.Label>
          <br></br>
          <input value={to} onChange={(event) => {
            setTo(event.target.value);
          } } />
        </Form.Group>

        <Form.Group>
          <Form.Label>Open Seat</Form.Label>
          <br></br>

          <input value={seat} onChange={(event) => {
            setSeat(event.target.value);
          } } />
        </Form.Group>
        <br></br>
        <div>
          <Button variant="primary" type="submit" onClick={save}>Submit</Button>
        </div>
      </Form>

      <br></br>

      <Table striped bordered hover align="center">
        <thead>
          <tr>
            <th scope="col">Airline Name</th>
            <th scope="col">Flight No</th>
            <th scope="col">From</th>
            <th scope="col">To</th>
            <th scope="col">Seat Availability</th>
          </tr>
        </thead>
        {Airline.map(function fn(Airline) {
          return (
            <tbody>
              <tr>
                <td>{Airline.name}</td>
                <td>{Airline.flightNo}</td>
                <td>{Airline.from}</td>
                <td>{Airline.to}</td>
                <td>{Airline.seat}</td>
              </tr>
            </tbody>
          );
        })}
      </Table>
    </div>
  );
}

export default Airlines