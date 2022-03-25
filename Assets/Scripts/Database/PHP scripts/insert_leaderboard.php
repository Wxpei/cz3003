<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user

    $username = $_POST["username"];
    $score = $_POST["score"];
    $topic = $_POST["topic"];
	$difficulty = $_POST["difficulty"];
    //$username = "frank";
    //$score = 2;
	//$topic = "maths";
	//$difficulty = "easy";
	
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}

	$sql = "INSERT INTO leaderboard 
            VALUES ('$username', '$score', '$topic', '$difficulty')";  
	$result = $conn ->query($sql);
	$affected = $conn -> affected_rows;
    echo $affected;
    if($affected == 1){
        echo 'Inserted';
    } else{
        echo 'Did not insert';
    }
	$conn->close();
?>