<?php
//echo '<pre>'.print_r(pathinfo(__FILE__),true).'</pre>';

$connection = mysqli_connect('localhost','homeworks','qwerty','homework');

if(!$connection){
	// go to error page
	echo 'No connection with database';
	exit;
}

//mysqli_query($connection,'SET NAMES utf8');
mysqli_set_charset($connection,'UTF8');

// insert username and password to database
function addUser($username, $password, $connection){
	$username = mysqli_escape_string($connection,$username);
	$password = mysqli_escape_string($connection,$password);
	$sql = 'INSERT INTO users (user_name, password, date_registered) VALUES ("'.$username.'","'.$password.'",Now())';
	if(mysqli_query($connection,$sql)){
		echo '<h3>You are sucsefull add</h3>';
		}
	else 
	{
		echo '<h3>You are not add</h3>';
	}	
}

function generateUsers($num_users, $connection){
	for($i = 1; $i < $num_users;$i++){
		$sql = 'INSERT INTO users (user_name, password, date_registered, is_active, age) VALUES ("demo '.$i.'","querty", Now() ,'.rand(0,1).','.rand(5,70).')';
		mysqli_query($connection,$sql);
	}
}

function getMessage($connection){
	$sql = 'SELECT * FROM msg ORDER BY date DESC';
	$result = mysqli_query($connection,$sql);
	$data = '';
	while($row = $result->fetch_assoc())
	{
		$data = $row['date'];
		$userId = $row['user_id'];
		$title = $row['title'];
		$content = $row['content'];
		$sql_queru = 'SELECT user_name FROM users WHERE userId = '.$userId.'';
		$username = mysqli_query($connection,$sql_queru);
		$username = $username->fetch_assoc();
		$username  = $username['user_name'];
		echo '<tr><td>'
		.$data
		.'</td><td>'
		.$username
		.'</td><td>'
		.$title
		.'</td><td>'
		.$content
		.'</td></tr>';
	}
}

function isValidLogin($username, $password, $connection){
	$username = mysqli_escape_string($connection,$username);
	$password = mysqli_escape_string($connection,$password );
	$sql = 'SELECT user_name, password FROM users WHERE user_name = "'.$username.'" AND password = "'.$password.'"';
	$result = mysqli_query($connection,$sql);
	if($result->num_rows>0){
		$_SESSION['username'] = $username;
		header('Location: message.php');
	}else{
		return false;
	}
}

function getUserIdByName($username, $connection){
	$sql = 'SELECT userId FROM users WHERE user_name = "'.$username.'"';
	$result = mysqli_query($connection, $sql);
	$userId = $result->fetch_assoc();
	return $userId['userId'];
}
function checkAvailibaleUsername($username, $connection){
	$sql = 'SELECT userId FROM users WHERE user_name = "'.$username.'"';
	$result = mysqli_query($connection, $sql);
	if($result->num_rows >0)
	{
		return true;
	}
	else
	{
		return false;
	}
}


function sendMessage($title, $message, $connection){
	$title = mysqli_escape_string($connection,$title);
	$message = mysqli_escape_string($connection,$message);
	$username = $_SESSION['username'];
	$userId = getUserIdByName($username, $connection);
	$sql = 'INSERT INTO 
	msg (title, content, date, user_id) 
	VALUES ("'.$title.'","'.$message.'",Now(),'.$userId.')';
	if(mysqli_query($connection,$sql))
	{
		header('Location: message.php');
	}
}
	
	/* 
while($row = $result->fetch_assoc()){
	echo '<pre>'.print_r($row,true).'</pre>';
}
 */

/* 
get by index
while($row = $result->fetch_row()){
	echo '<pre>'.print_r($row,true).'</pre>';
} 
*/
/* 
// get index and value	
while($row = $result->fetch_array()){
	echo '<pre>'.print_r($row,true).'</pre>';
}
 */
/* 
while($row = $result->fetch_object()){
	echo '<pre>'.print_r($row,true).'</pre>';
}
 */