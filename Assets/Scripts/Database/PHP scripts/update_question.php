<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user
    $question_id = $_POST["question_id"];
    $question_description = $_POST["question_description"];
    $answer_1 = $_POST["answer_1"];
    $answer_2 = $_POST["answer_2"];
    $answer_3 = $_POST["answer_3"];
    $answer_4 = $_POST["answer_4"];
    $correct_answer = $_POST["correct_answer"];
    $topic = $_POST["topic"];
	$difficulty = $_POST["difficulty"];

    // $question_id = 23;
    // $question_description = "aaa question";
    // $answer_1 = "1";
    // $answer_2 = "2";
    // $answer_3 = "3";
    // $answer_4 = "4";
    // $correct_answer = "4";
    // $topic = "math";
	// $difficulty = "easy";
	
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}

	$sql = "UPDATE question_bank
            SET question_description = '$question_description', answer_1 = '$answer_1', answer_2 = '$answer_2', answer_3 = '$answer_3', answer_4 = '$answer_4',
            correct_answer = '$correct_answer', topic = '$topic', difficulty = '$difficulty', assignment_id = 0
            WHERE question_id = '$question_id'";

	$result = $conn ->query($sql);
	$affected = $conn -> affected_rows;
    echo $affected;
    if($affected == 1){
        echo 'Question Updated';
    } else{
        echo 'Did not Update';
    }
	$conn->close();
?>