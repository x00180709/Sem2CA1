import { check } from "k6";
import http from "k6/http";


export let options = {
  // This stages configuration will ramp to 20 Virtual Users over a minute,
  // maintain those 20 concurrent users for 1 minute
  // then ramp down to 0 over a minute i.e. ramp-up pattern of "load"
  stages: [
    { duration: "1m", target: 20 },            
    { duration: "1m", target: 20 },
    { duration: "1m", target: 0 }             
  ],
  
  // setting a threshold at 200ms request duration for 95th percentile
  // i.e. 95% of request duration times should be < 100 ms
 	thresholds: {
    "http_req_duration": ["p(95) < 200"]
  },

  // Don't save the bodies of HTTP responses
  discardResponseBodies: false,

  ext: {
    loadimpact: {
      distribution: {
        loadZoneLabel1: { loadZone: "amazon:ie:dublin", percent: 100 }
      }
    }
  }
};

function getRandomInt(min, max) {
  return Math.floor(Math.random() * (max - min + 1) + min);
}

export default function() {
 
  // do an initial GET, force response body so that form can be subsequently submited
  let res = http.get("https://bloodpressuredm.azurewebsites.net", {"responseType": "text"});

  check(res, {
    "is status 200": (r) => r.status === 200
  });

  // POST with random data to prevent server cached response to POST, discard response body
  // res = res.submitForm({
  //   fields: { Bmi_WeightStones: getRandomInt(5, 50).toString(), Bmi_WeightPounds: getRandomInt(0, 13).toString(), 
  //             Bmi_HeightFeet: getRandomInt(4, 7).toString(), Bmi_HeightInches: getRandomInt(0, 11).toString()}
  // });

  // check(res, {
  //   "is status 200": (r) => r.status === 200
  // });
}