-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 01, 2022 at 05:46 AM
-- Server version: 10.4.20-MariaDB
-- PHP Version: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cz3003`
--

-- --------------------------------------------------------

--
-- Table structure for table `leaderboard`
--

CREATE TABLE `leaderboard` (
  `username` varchar(255) NOT NULL,
  `score` int(255) NOT NULL,
  `topic` varchar(255) NOT NULL,
  `difficulty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `leaderboard`
--

INSERT INTO `leaderboard` (`username`, `score`, `topic`, `difficulty`) VALUES
('ben', 5, 'math', 'easy'),
('john', 4, 'math', 'easy'),
('tim', 1, 'math', 'easy'),
('lisa', 4, 'math', 'easy'),
('frank', 2, 'math', 'easy'),
('james', 5, 'science', 'easy'),
('emily', 5, 'science', 'easy'),
('nicole', 4, 'science', 'normal'),
('anna', 3, 'science', 'hard'),
('scott', 3, 'science', 'hard'),
('jason', 2, 'math', 'hard'),
('emma', 4, 'math', 'hard'),
('henry', 3, 'math', 'hard'),
('janet', 3, 'math', 'hard'),
('debra', 4, 'science', 'normal'),
('dennis', 2, 'science', 'normal'),
('ryan', 4, 'science', 'normal'),
('kelly', 5, 'science', 'normal');

-- --------------------------------------------------------

--
-- Table structure for table `leaderboard_custom`
--

CREATE TABLE `leaderboard_custom` (
  `username` varchar(255) NOT NULL,
  `score` varchar(255) NOT NULL,
  `time` varchar(255) NOT NULL,
  `assignment_id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `leaderboard_custom`
--

INSERT INTO `leaderboard_custom` (`username`, `score`, `time`, `assignment_id`) VALUES
('ben', '5', '1:21', '123'),
('john', '5', '2:21', '123');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `isTeacher` int(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`username`, `password`, `isTeacher`, `Name`, `Email`) VALUES
('john', '$2y$10$1bEFWxjqHJDJ7EU2NlyNqevymimOvNfNhtuVNpEvFANp2El.J1iCa', 0, 'John', 'john@gmail.com'),
('ben', '$2y$10$1bEFWxjqHJDJ7EU2NlyNqevymimOvNfNhtuVNpEvFANp2El.J1iCa', 0, 'Ben', 'Ben@gmail.com'),
('admin', '$2y$10$1bEFWxjqHJDJ7EU2NlyNqevymimOvNfNhtuVNpEvFANp2El.J1iCa', 1, 'admin', 'admin'),
('john555', '123', 0, 'test', 'test'),
('lisa', 'password1', 0, 'Lisa', 'lisa@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `question_bank`
--

CREATE TABLE `question_bank` (
  `question_id` int(11) NOT NULL,
  `question_description` varchar(255) NOT NULL,
  `answer_1` varchar(255) NOT NULL,
  `answer_2` varchar(255) NOT NULL,
  `answer_3` varchar(255) NOT NULL,
  `answer_4` varchar(255) NOT NULL,
  `correct_answer` varchar(255) NOT NULL,
  `topic` varchar(255) NOT NULL,
  `difficulty` varchar(255) NOT NULL,
  `assignment_id` varchar(255) NOT NULL,
  `total_attempts` int(11) NOT NULL DEFAULT 0,
  `correct_attempts` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `question_bank`
--

INSERT INTO `question_bank` (`question_id`, `question_description`, `answer_1`, `answer_2`, `answer_3`, `answer_4`, `correct_answer`, `topic`, `difficulty`, `assignment_id`, `total_attempts`, `correct_attempts`) VALUES
(1, 'sin(sec-1 x + cosec-1x) =', '1', '-1', 'π/2', 'π/3', '1', 'math', 'normal', '0', 20, 14),
(2, 'The principle value of sin-1 (√3/2) is', '2π/3', 'π/6', 'π/4', 'π/3', 'π/3', 'math', 'normal', '0', 17, 11),
(3, 'Simplified form of cos-1 (4x3 – 3x)', '3 sin-1x', '3 cos-1x', 'π – 3 sin-1x', 'none of the above', '3 cos-1x', 'math', 'hard', '0', 0, 0),
(4, 'If y = sec-1 x then', '0 ≤ y ≤ π', '0 ≤ y ≤ π/2', '–π/2 < y < π/2', 'none of the above', 'none of the above', 'math', 'hard', '0', 0, 0),
(5, 'If x + (1/𝑥) = 2 then the principal value of sin-1 x is', 'π/4', 'π/2', 'π', '3π/2', 'π/2', 'math', 'hard', '0', 0, 0),
(6, 'The principle value of sin-1 (sin2π/3) is', '2π/3', 'π/3', '-π/6', 'π/6', 'π/3', 'math', 'hard', '0', 0, 0),
(7, 'The value of cos - 1 (1/2) + 2sin - 1 (1/2) is equal to', 'π/4', 'π/6', '2π/3', '5π/6', 'π/6', 'math', 'hard', '0', 0, 0),
(8, 'Principal value of tan -1 ( -1) is', 'π/4', '-π/2', '5π/4', '-π/4', '-π/4', 'math', 'hard', '0', 0, 0),
(9, 'Principal value of sin - 1 (1/√2 )', 'π/4', '3π/4', '5π/4', 'none of the above', 'π/4', 'math', 'hard', '0', 0, 0),
(10, 'The nucleus of an atom consists of', 'electrons and neutrons', 'electrons and protons', 'protons and neutrons', 'All of the above', 'protons and neutrons', 'science', 'easy', '0', 0, 0),
(11, 'The nucleus of a hydrogen atom consists of', '1 proton only', '1 proton + 2 neutron', '1 neutron only', '1 electron only', '1 proton only', 'science', 'easy', '0', 0, 0),
(12, 'Pa(Pascal) is the unit for', 'thrust', 'pressure', 'frequency', 'conductivity', 'pressure', 'science', 'easy', '0', 0, 0),
(13, 'Metals are good conductors of electricity because', 'they contain free electrons', 'the atoms are lightly packed', 'they have high melting point', 'All of the above', 'they contain free electrons', 'science', 'easy', '0', 0, 0),
(14, 'The liquid metal is', 'Bismuth', 'Magnesium', 'Mercury', 'Sodium', 'Mercury', 'science', 'easy', '0', 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `question_bank`
--
ALTER TABLE `question_bank`
  ADD UNIQUE KEY `question_id` (`question_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `question_bank`
--
ALTER TABLE `question_bank`
  MODIFY `question_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
