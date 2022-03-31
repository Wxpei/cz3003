<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user
	$topic = $_POST["topic"];
	$difficulty = $_POST["difficulty"];
	//$topic = "maths";
	//$difficulty = "easy";
	
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}

	$sql = "Select `question_description`,`answer_1`,`answer_2`,`answer_3`,`answer_4`,`correct_answer` FROM question_bank where topic = '$topic' AND difficulty ='$difficulty' " ;  
	$result = $conn ->query($sql);

	if($result->num_rows > 0)
	{
		$rows = array();
        while($row = $result->fetch_assoc())
        {
            $rows[] = $row;
        }
        echo json_encode($rows);
	}
    else{
        echo "failed";
    }
	$conn->close();
?>