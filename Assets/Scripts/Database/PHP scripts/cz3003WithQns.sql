-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 03, 2022 at 06:41 AM
-- Server version: 10.3.16-MariaDB
-- PHP Version: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
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
('kelly', 5, 'science', 'normal'),
('adminStudent', 5, 'science', 'easy'),
('adminStudent', 10, 'science', 'normal'),
('adminStudent', 15, 'history', 'hard'),
('adminStudent2', 10, 'social studies', 'normal');

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
('john', '5', '2:21', '123'),
('adminStudent', '5', '32.3331', '1'),
('adminStudent2', '5', '33.0433', '1');

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
(1, 'sin(sec-1 x + cosec-1x) =', '1', '-1', 'π/2', 'π/3', '1', 'math', 'normal', '0', 21, 15),
(2, 'The principle value of sin-1 (√3/2) is', '2π/3', 'π/6', 'π/4', 'π/3', 'π/3', 'math', 'normal', '0', 18, 12),
(3, 'Simplified form of cos-1 (4x3 – 3x)', '3 sin-1x', '3 cos-1x', 'π – 3 sin-1x', 'none of the above', '3 cos-1x', 'math', 'hard', '0', 0, 0),
(4, 'If y = sec-1 x then', '0 ≤ y ≤ π', '0 ≤ y ≤ π/2', '–π/2 < y < π/2', 'none of the above', 'none of the above', 'math', 'hard', '0', 0, 0),
(5, 'If x + (1/𝑥) = 2 then the principal value of sin-1 x is', 'π/4', 'π/2', 'π', '3π/2', 'π/2', 'math', 'hard', '0', 0, 0),
(6, 'The principle value of sin-1 (sin2π/3) is', '2π/3', 'π/3', '-π/6', 'π/6', 'π/3', 'math', 'hard', '0', 0, 0),
(7, 'The value of cos - 1 (1/2) + 2sin - 1 (1/2) is equal to', 'π/4', 'π/6', '2π/3', '5π/6', 'π/6', 'math', 'hard', '0', 0, 0),
(8, 'Principal value of tan -1 ( -1) is', 'π/4', '-π/2', '5π/4', '-π/4', '-π/4', 'math', 'hard', '0', 0, 0),
(9, 'Principal value of sin - 1 (1/√2 )', 'π/4', '3π/4', '5π/4', 'none of the above', 'π/4', 'math', 'hard', '0', 0, 0),
(10, 'The nucleus of an atom consists of', 'electrons and neutrons', 'electrons and protons', 'protons and neutrons', 'All of the above', 'protons and neutrons', 'science', 'easy', '0', 13, 10),
(11, 'The nucleus of a hydrogen atom consists of', '1 proton only', '1 proton + 2 neutron', '1 neutron only', '1 electron only', '1 proton only', 'science', 'easy', '0', 14, 10),
(12, 'Pa(Pascal) is the unit for', 'thrust', 'pressure', 'frequency', 'conductivity', 'pressure', 'science', 'easy', '0', 14, 9),
(13, 'Metals are good conductors of electricity because', 'they contain free electrons', 'the atoms are lightly packed', 'they have high melting point', 'All of the above', 'they contain free electrons', 'science', 'easy', '0', 13, 10),
(14, 'The liquid metal is', 'Bismuth', 'Magnesium', 'Mercury', 'Sodium', 'Mercury', 'science', 'easy', '0', 14, 14),
(15, 'Science easy 1 (Rm1)', 'test 1', 'test 2', 'test 3', 'test 4', 'test 1', 'science', 'easy', '1', 7, 6),
(16, 'Science easy 2 (Rm1)', 'test 1', 'test 2', 'test 3', 'test 4', 'test 2', 'science', 'easy', '1', 4, 3),
(17, 'Science easy 3 (Rm1)', 'test 1', 'test 2', 'test 3', 'test 4', 'test 3', 'science', 'easy', '1', 6, 4),
(18, 'Science easy 4 (Rm1)', 'test 1', 'test 2', 'test 3', 'test 4', 'test 4', 'science', 'easy', '1', 6, 6),
(19, 'Science easy 5 (Rm1)', 'test 5', 'test 6', 'test 7', 'test 8', 'test 5', 'science', 'easy', '1', 4, 2),
(20, 'Science easy 6 (Rm1)', 'test 5', 'test 6', 'test 7', 'test 8', 'test 6', 'science', 'easy', '1', 5, 5),
(21, 'science easy 6', '5', '6', '7', '8', '6', 'science', 'easy', '0', 2, 2),
(22, 'Math normal 3', '1', '2', '3', '4', '3', 'math', 'normal', '0', 0, 0),
(23, 'Math normal 4', '1', '2', '3', '4', '4', 'math', 'normal', '0', 0, 0),
(24, 'Math normal 5', '5', '6', '7', '8', '5', 'math', 'normal', '0', 0, 0),
(25, 'Math normal 6', '5', '6', '7', '8', '6', 'math', 'normal', '0', 0, 0),
(26, 'Math normal 7', '5', '6', '7', '8', '7', 'math', 'normal', '0', 0, 0),
(27, 'Math easy 1', '1', '2', '3', '4', '1', 'math', 'easy', '0', 1, 1),
(28, 'Math easy 2', '1', '2', '3', '4', '2', 'math', 'easy', '0', 0, 0),
(29, 'Math easy 3', '1', '2', '3', '4', '3', 'math', 'easy', '0', 1, 1),
(30, 'Math easy 4', '1', '2', '3', '4', '4', 'math', 'easy', '0', 1, 0),
(31, 'Math easy 5', '5', '6', '7', '8', '5', 'math', 'easy', '0', 0, 0),
(32, 'Math easy 6', '5', '6', '7', '8', '6', 'math', 'easy', '0', 1, 1),
(33, 'Math easy 7', '5', '6', '7', '8', '7', 'math', 'easy', '0', 1, 1),
(34, 'geography easy 1', '1', '2', '3', '4', '1', 'geography', 'easy', '0', 0, 0),
(35, 'geography easy 2', '1', '2', '3', '4', '2', 'geography', 'easy', '0', 0, 0),
(36, 'geography easy 3', '1', '2', '3', '4', '3', 'geography', 'easy', '0', 0, 0),
(37, 'geography easy 4', '1', '2', '3', '4', '4', 'geography', 'easy', '0', 0, 0),
(38, 'geography easy 5', '5', '6', '7', '8', '5', 'geography', 'easy', '0', 0, 0),
(39, 'geography easy 6', '5', '6', '7', '8', '6', 'geography', 'easy', '0', 0, 0),
(40, 'geography easy 7', '5', '6', '7', '8', '7', 'geography', 'easy', '0', 0, 0),
(41, 'geography normal 1', '1', '2', '3', '4', '1', 'geography', 'normal', '0', 0, 0),
(42, 'geography normal 2', '1', '2', '3', '4', '2', 'geography', 'normal', '0', 0, 0),
(43, 'geography normal 3', '1', '2', '3', '4', '3', 'geography', 'normal', '0', 0, 0),
(44, 'geography normal 4', '1', '2', '3', '4', '4', 'geography', 'normal', '0', 0, 0),
(45, 'geography normal 5', '5', '6', '7', '8', '5', 'geography', 'normal', '0', 0, 0),
(46, 'geography normal 6', '5', '6', '7', '8', '6', 'geography', 'normal', '0', 0, 0),
(47, 'geography normal 7', '5', '6', '7', '8', '7', 'geography', 'normal', '0', 0, 0),
(48, 'geography hard 1', '1', '2', '3', '4', '1', 'geography', 'hard', '0', 0, 0),
(49, 'geography hard 2', '1', '2', '3', '4', '2', 'geography', 'hard', '0', 0, 0),
(50, 'geography hard 3', '1', '2', '3', '4', '3', 'geography', 'hard', '0', 0, 0),
(51, 'geography hard 4', '1', '2', '3', '4', '4', 'geography', 'hard', '0', 0, 0),
(52, 'geography hard 5', '5', '6', '7', '8', '5', 'geography', 'hard', '0', 0, 0),
(53, 'geography hard 6', '5', '6', '7', '8', '6', 'geography', 'hard', '0', 0, 0),
(54, 'geography hard 7', '5', '6', '7', '8', '7', 'geography', 'hard', '0', 0, 0),
(55, 'history easy 1', '1', '2', '3', '4', '1', 'history', 'easy', '0', 0, 0),
(56, 'history easy 2', '1', '2', '3', '4', '2', 'history', 'easy', '0', 0, 0),
(57, 'history easy 3', '1', '2', '3', '4', '3', 'history', 'easy', '0', 0, 0),
(58, 'history easy 4', '1', '2', '3', '4', '4', 'history', 'easy', '0', 0, 0),
(59, 'history easy 5', '5', '6', '7', '8', '5', 'history', 'easy', '0', 0, 0),
(60, 'history easy 6', '5', '6', '7', '8', '6', 'history', 'easy', '0', 0, 0),
(61, 'history easy 7', '5', '6', '7', '8', '7', 'history', 'easy', '0', 0, 0),
(62, 'history normal 1', '1', '2', '3', '4', '1', 'history', 'normal', '0', 0, 0),
(63, 'history normal 2', '1', '2', '3', '4', '2', 'history', 'normal', '0', 0, 0),
(64, 'history normal 3', '1', '2', '3', '4', '3', 'history', 'normal', '0', 0, 0),
(65, 'history normal 4', '1', '2', '3', '4', '4', 'history', 'normal', '0', 0, 0),
(66, 'history normal 5', '5', '6', '7', '8', '5', 'history', 'normal', '0', 0, 0),
(67, 'history normal 6', '5', '6', '7', '8', '6', 'history', 'normal', '0', 0, 0),
(68, 'history normal 7', '5', '6', '7', '8', '7', 'history', 'normal', '0', 0, 0),
(69, 'history hard 1', '1', '2', '3', '4', '1', 'history', 'hard', '0', 1, 1),
(70, 'history hard 2', '1', '2', '3', '4', '2', 'history', 'hard', '0', 1, 1),
(71, 'history hard 3', '1', '2', '3', '4', '3', 'history', 'hard', '0', 1, 1),
(72, 'history hard 4', '1', '2', '3', '4', '4', 'history', 'hard', '0', 1, 1),
(73, 'history hard 5', '5', '6', '7', '8', '5', 'history', 'hard', '0', 0, 0),
(74, 'history hard 6', '5', '6', '7', '8', '6', 'history', 'hard', '0', 1, 1),
(75, 'history hard 7', '5', '6', '7', '8', '7', 'history', 'hard', '0', 0, 0),
(76, 'social studies easy 1', '1', '2', '3', '4', '1', 'social studies', 'easy', '0', 0, 0),
(77, 'social studies easy 2', '1', '2', '3', '4', '2', 'social studies', 'easy', '0', 0, 0),
(78, 'social studies easy 3', '1', '2', '3', '4', '3', 'social studies', 'easy', '0', 0, 0),
(79, 'social studies easy 4', '1', '2', '3', '4', '4', 'social studies', 'easy', '0', 0, 0),
(80, 'social studies easy 5', '5', '6', '7', '8', '5', 'social studies', 'easy', '0', 0, 0),
(81, 'social studies easy 6', '5', '6', '7', '8', '6', 'social studies', 'easy', '0', 0, 0),
(82, 'social studies easy 7', '5', '6', '7', '8', '7', 'social studies', 'easy', '0', 0, 0),
(83, 'social studies normal 1', '1', '2', '3', '4', '1', 'social studies', 'normal', '0', 1, 1),
(84, 'social studies normal 2', '1', '2', '3', '4', '2', 'social studies', 'normal', '0', 1, 1),
(85, 'social studies normal 3', '1', '2', '3', '4', '3', 'social studies', 'normal', '0', 1, 1),
(86, 'social studies normal 4', '1', '2', '3', '4', '4', 'social studies', 'normal', '0', 1, 1),
(87, 'social studies normal 5', '5', '6', '7', '8', '5', 'social studies', 'normal', '0', 1, 1),
(88, 'social studies normal 6', '5', '6', '7', '8', '6', 'social studies', 'normal', '0', 0, 0),
(89, 'social studies normal 7', '5', '6', '7', '8', '7', 'social studies', 'normal', '0', 0, 0),
(90, 'social studies hard 1', '1', '2', '3', '4', '1', 'social studies', 'hard', '0', 0, 0),
(91, 'social studies hard 2', '1', '2', '3', '4', '2', 'social studies', 'hard', '0', 0, 0),
(92, 'social studies hard 3', '1', '2', '3', '4', '3', 'social studies', 'hard', '0', 0, 0),
(93, 'social studies hard 4', '1', '2', '3', '4', '4', 'social studies', 'hard', '0', 0, 0),
(94, 'social studies hard 5', '5', '6', '7', '8', '5', 'social studies', 'hard', '0', 0, 0),
(95, 'social studies hard 6', '5', '6', '7', '8', '6', 'social studies', 'hard', '0', 0, 0),
(96, 'social studies hard 7', '5', '6', '7', '8', '7', 'social studies', 'hard', '0', 0, 0),
(97, 'math hard 1', '1', '2', '3', '4', '1', 'math', 'hard', '0', 0, 0),
(98, 'math hard 2', '1', '2', '3', '4', '2', 'math', 'hard', '0', 0, 0),
(99, 'math hard 3', '1', '2', '3', '4', '3', 'math', 'hard', '0', 0, 0),
(100, 'math hard 4', '1', '2', '3', '4', '4', 'math', 'hard', '0', 0, 0),
(101, 'math hard 5', '5', '6', '7', '8', '5', 'math', 'hard', '0', 0, 0),
(102, 'math hard 6', '5', '6', '7', '8', '6', 'math', 'hard', '0', 0, 0),
(103, 'math hard 7', '5', '6', '7', '8', '7', 'math', 'hard', '0', 0, 0),
(104, 'science normal 1', '1', '2', '3', '4', '1', 'science', 'normal', '0', 1, 1),
(105, 'science normal 2', '1', '2', '3', '4', '2', 'science', 'normal', '0', 1, 1),
(106, 'science normal 3', '1', '2', '3', '4', '3', 'science', 'normal', '0', 0, 0),
(107, 'science normal 4', '1', '2', '3', '4', '4', 'science', 'normal', '0', 1, 1),
(108, 'science normal 5', '5', '6', '7', '8', '5', 'science', 'normal', '0', 0, 0),
(109, 'science normal 6', '5', '6', '7', '8', '6', 'science', 'normal', '0', 1, 1),
(110, 'science normal 7', '5', '6', '7', '8', '7', 'science', 'normal', '0', 1, 1),
(111, 'science hard 1', '1', '2', '3', '4', '1', 'science', 'hard', '0', 0, 0),
(112, 'science hard 2', '1', '2', '3', '4', '2', 'science', 'hard', '0', 0, 0),
(113, 'science hard 3', '1', '2', '3', '4', '3', 'science', 'hard', '0', 0, 0),
(114, 'science hard 4', '1', '2', '3', '4', '4', 'science', 'hard', '0', 0, 0),
(115, 'science hard 5', '5', '6', '7', '8', '5', 'science', 'hard', '0', 0, 0),
(116, 'science hard 6', '5', '6', '7', '8', '6', 'science', 'hard', '0', 0, 0),
(117, 'science hard 7', '5', '6', '7', '8', '7', 'science', 'hard', '0', 0, 0);

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
  MODIFY `question_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=118;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
