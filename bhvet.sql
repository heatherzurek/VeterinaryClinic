-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 14, 2019 at 11:43 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bhvet`
--
CREATE DATABASE IF NOT EXISTS `bhvet` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `bhvet`;

-- --------------------------------------------------------

--
-- Table structure for table `appts`
--

CREATE TABLE `appts` (
  `id` int(11) NOT NULL,
  `vet_id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `appts`
--

INSERT INTO `appts` (`id`, `vet_id`, `patient_id`) VALUES
(1, 0, 2),
(2, 0, 2),
(3, 0, 2),
(4, 0, 2),
(5, 0, 2),
(6, 0, 2),
(7, 0, 2),
(8, 0, 2),
(9, 0, 2),
(10, 0, 2),
(11, 0, 1),
(12, 6, 3),
(13, 6, 3),
(14, 3, 3),
(15, 2, 4);

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE `patients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `visit_reason` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `dob` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `patients`
--

INSERT INTO `patients` (`id`, `name`, `visit_reason`, `type`, `dob`) VALUES
(1, 'Larry', '', '', '0000-00-00'),
(2, 'Lil\' George', '', '', '0000-00-00'),
(3, 'Piggy', '', '', '0000-00-00'),
(4, 'Mooy', '', '', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `vets`
--

CREATE TABLE `vets` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='party all the time';

--
-- Dumping data for table `vets`
--

INSERT INTO `vets` (`id`, `name`, `specialty`) VALUES
(1, 'Dr butts', ''),
(2, 'Brian', 'Heart Surgery'),
(3, 'Reese', 'Brain Dr'),
(4, 'Jared', 'Assistant to the regional manager'),
(5, 'Dr. Jared', 'Not a vet'),
(6, 'Ronald McVet', 'Farm Animals');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `appts`
--
ALTER TABLE `appts`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `vets`
--
ALTER TABLE `vets`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appts`
--
ALTER TABLE `appts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `patients`
--
ALTER TABLE `patients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `vets`
--
ALTER TABLE `vets`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
