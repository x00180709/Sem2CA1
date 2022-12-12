import { check } from "k6";
import http from "k6/http";


export let options = {
  // This stages configuration will ramp to 20 Virtual Users over 30s,
  // maintain those 20 concurrent users for 30s
  // spike to 100 users for 30s
  // then ramp down to 0 30s i.e. ramp-up pattern of "spike"
  stages: [
    { duration: "30s", target: 10 },            
    { duration: "30s", target: 10 },
    { duration: "30s", target: 30 },
    { duration: "30s", target: 0 }             
  ],
  
  // 95% of request duration times should be < 200 ms
 	thresholds: {
    "http_req_duration": ["p(90) < 200"]
  },

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
  let res = http.get("https://bloodpressuredm-staging.azurewebsites.net", {"responseType": "text"});

  check(res, {
    "is status 200": (r) => r.status === 200
  });

  // POST with random data to prevent server cached response to POST, discard response body
  res = res.submitForm({
    fields: { BP_Systolic: getRandomInt(100, 190).toString(), BP_Diastolic: getRandomInt(40, 100).toString()}
  });

  check(res, {
    "is status 200": (r) => r.status === 200
  });
}