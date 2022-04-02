<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user
    $question_id = $_POST["question_id"];
    $correct_attempt = $_POST["correct_attempt"];

    // $question_id = 1;
    // $correct_attempt = 0;
	
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}

    if ($correct_attempt == 1){
        $sql = "UPDATE question_bank
            SET total_attempts = total_attempts + 1, correct_attempts = correct_attempts + 1
            WHERE question_id = '$question_id'";
    } 
    else{
        $sql = "UPDATE question_bank
        SET total_attempts = total_attempts + 1
        WHERE question_id = '$question_id'";
    }
	
	$result = $conn ->query($sql);
	$affected = $conn -> affected_rows;
    echo $affected;
    if($affected == 1){
        echo 'Question Stats Updated';
    } else{
        echo 'Did not Update Question Stats';
    }
	$conn->close();
?>