/*
* File Name : Example.js
* Author : Someone
* Date : 5/31/2016
* Version : 0.0.1
* Desription : I choose NodeJS to rewiter Pause.php file.
*/

// require file 
var http = require('http');
var qs = require('querystring');
var url = require('url');
var crypto = require('crypto');
var fs = require('fs');

// get hash
var sha256 = crypto.createHash('sha256');
var key;
// main url string.
var urlStr = 'http://jobs.pause.ca/submit.php';

var resumefile = 'C:/Users/Lingchen/Desktop/resume.pdf';

// Your full name
var name = 'Lingchen Meng';

// Your phone number
var phone = '(519)-781-3702';

// Your email address
var email = 'menglingchen3019@gmail.com';

// The message we want to send
var subject = 'My developer application';

// Any additional notes you wish to include
// Bonus points if you discover the security issue with this script or
// have ideas for improvements and note them here.
var notes = '';

// array hold all data.
var postArr = {};
postArr['name'] = name;
postArr['phone'] = phone;
postArr['email'] = email;
postArr['subject'] = subject;
postArr['notes'] = notes;
postArr['time'] = Date.now();

// make query string by array.
var postData = qs.stringify({
	name: postArr['name'],
	phone: postArr['phone'],
	email: postArr['email'],
	subject: postArr['subject'],
	notes: postArr['notes'],
	time: postArr['time']
});

// set opstions for request.
var options = {
	hostname: 'jobs.pause.ca',
	port: 80,
	method: 'POST',
	path: '/submit.php',
	headers:{
		'content-type': 'application/x-www-form-urlencoded',
		'content-length': postData.length
	}
};

var tempTime;
// using http.request to get response from 'http://jobs.pause.ca/submit.php' by POST method.
var req = http.request(options, (res)=>{

  	  res.setEncoding('utf8');
	  res.on('data', (chunk) => {
	    //decode the json encoded response
	    var arr = JSON.parse(chunk);
	    // set data to array.
	    key =  arr['application-secret-key'];
	    postArr['application-id'] = arr['application-id'];

	    tempTime = postArr['time'].toString() + key;

	  });
	  res.on('end', () => {
	    console.log('No more data in response.')
	  })
});

req.on('error', (e) => {
  console.log(`problem with request: ${e.message}`);
});

// write data to request body
req.write(postData);
req.end();

// 2
// Hash the resulting string from step 3 using SHA256. This is your signature.
setTimeout(function () {
  postData = qs.stringify({
	'application-id': postArr['application-id'],
	email: postArr['email'],
	name: postArr['name'],
	notes: postArr['notes'],
	phone: postArr['phone'],
	subject: postArr['subject'],
	time: tempTime
});
}, 1000);

var signature = crypto.createHash('sha256').update(postData).digest('hex');
postArr['sig'] = signature;

// check file whether exist.
fs.stat(resumefile, function(err, stat) {
    if(err == null) {
        console.log('File exists');
    } else if(err.code == 'ENOENT') {
        // file does not exist
        fs.writeFile('log.txt', 'Some log\n');
    } else {
        console.log('Some other error: ', err.code);
    }
});


// Add the file to upload
postArr['resume'] = resumefile;

// Include this script (we'd like to see your work please!)
postArr['script'] = 'C:/Users/Lingchen/Desktop/Example.js';

console.log('Submitting application...\n');

setTimeout(function () {
  postData = qs.stringify({
	'application-id': postArr['application-id'],
	email: postArr['email'],
	name: postArr['name'],
	notes: postArr['notes'],
	phone: postArr['phone'],
	subject: postArr['subject'],
	time: tempTime,
	sig: postArr['sig'],
	resume: postArr['resume'],
	script: postArr['script']
});

  console.log(postData);
}, 1000);

// get new lenght of postData.
var option1 = {
	hostname: 'jobs.pause.ca',
	port: 80,
	method: 'POST',
	path: '/submit.php',
	headers:{
		'content-type': 'application/x-www-form-urlencoded',
		'content-length': postData.length
	}
};

// send second tiem. (Post the data to Pause's server)
var req2 = http.request(option1, (res)=>{

  	  res.setEncoding('utf8');
	  res.on('data', (ok) => {
	    console.log(`BODY: ${ok}`);
	  });
	  res.on('end', () => {
	    console.log('No more data in response.')
	  })
});

req2.on('error', (e) => {
  console.log(`problem with request: ${e.message}`);
});

// write data to request body
req2.write(postData);
req2.end();