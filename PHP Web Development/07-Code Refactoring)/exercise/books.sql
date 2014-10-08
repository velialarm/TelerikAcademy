-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Nov 03, 2013 at 06:19 PM
-- Server version: 5.6.12
-- PHP Version: 5.5.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `books`
--
CREATE DATABASE IF NOT EXISTS `books` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `books`;

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE IF NOT EXISTS `authors` (
  `author_id` int(11) NOT NULL AUTO_INCREMENT,
  `author_name` varchar(250) NOT NULL,
  PRIMARY KEY (`author_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`author_id`, `author_name`) VALUES
(1, 'Nicholas C. Zakas'),
(2, 'Shaun Mitchell'),
(3, 'Sander Schoneville'),
(4, 'Robbert Ravensbergen'),
(5, 'Jim Mlodgenski'),
(6, 'Kirk Roybal'),
(7, 'Hannu Krosing'),
(9, 'Димана К'),
(10, 'VENELIN PREMUDRI');

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE IF NOT EXISTS `books` (
  `book_id` int(11) NOT NULL AUTO_INCREMENT,
  `book_title` varchar(250) NOT NULL,
  PRIMARY KEY (`book_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`book_id`, `book_title`) VALUES
(1, 'Professional JavaScript for Web Developers, 3rd Edition'),
(2, 'SDL Game Development'),
(3, 'Magento: Beginner''s Guide, 2nd Edition'),
(4, 'PostgreSQL Server Programming'),
(5, 'Learning SQL Server'),
(8, 'ZA KOMPUTURA I TOALETNATA');

-- --------------------------------------------------------

--
-- Table structure for table `books_authors`
--

CREATE TABLE IF NOT EXISTS `books_authors` (
  `book_id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL,
  KEY `book_id` (`book_id`),
  KEY `author_id` (`author_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `books_authors`
--

INSERT INTO `books_authors` (`book_id`, `author_id`) VALUES
(1, 1),
(2, 2),
(3, 3),
(3, 4),
(4, 5),
(4, 6),
(4, 7),
(5, 1),
(5, 2),
(5, 4),
(5, 6),
(6, 5),
(6, 9),
(8, 10);

-- --------------------------------------------------------

--
-- Table structure for table `comments`
--

CREATE TABLE IF NOT EXISTS `comments` (
  `comment_id` int(11) NOT NULL AUTO_INCREMENT,
  `text` text NOT NULL,
  `date` datetime NOT NULL,
  `book_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  PRIMARY KEY (`comment_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=27 ;

--
-- Dumping data for table `comments`
--

INSERT INTO `comments` (`comment_id`, `text`, `date`, `book_id`, `user_id`) VALUES
(1, 'First comments... or.. ? ', '2013-10-25 23:09:39', 3, 3),
(2, 'haha mai se comentirah.. :) ', '2013-10-25 23:10:07', 3, 3),
(5, 'refresh me', '2013-10-25 23:23:35', 3, 3),
(6, 'opala', '2013-10-25 23:24:31', 3, 3),
(8, 'tova e nesho novo', '2013-10-25 23:26:53', 3, 3),
(10, 'gusto', '2013-10-25 23:28:40', 3, 3),
(11, 'kakvo novo', '2013-10-25 23:30:29', 3, 3),
(12, 'ehhaa', '2013-10-25 23:49:49', 3, 8),
(13, 'opa nqma komentarche li.. ', '2013-10-25 23:51:09', 4, 8),
(14, 'ihaa parvi komentiral', '2013-10-25 23:51:20', 2, 8),
(15, 'vtroi komentar', '2013-10-25 23:51:28', 2, 8),
(16, 'komentarsiuma ... ', '2013-10-25 23:53:55', 5, 8),
(17, 'parva kniga s komentara... ', '2013-10-26 00:00:47', 1, 8),
(18, 'opala4ka', '2013-10-26 00:02:49', 1, 8),
(19, 'leleee', '2013-10-26 00:02:57', 1, 8),
(20, 'nqma go', '2013-10-26 00:03:25', 5, 9),
(21, 'uhaa', '2013-10-26 00:04:38', 2, 9),
(22, 'tra-la-la', '2013-10-26 00:04:58', 5, 10),
(23, 'mai raboti ... ', '2013-10-26 00:05:10', 5, 10),
(24, 'mnogo ', '2013-10-26 00:13:37', 1, 11),
(25, 'aloooo', '2013-10-26 01:20:33', 8, 11),
(26, 'koi be :)', '2013-10-26 01:20:58', 8, 12);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(120) NOT NULL,
  `password` varchar(120) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`) VALUES
(1, 'venko', '12345'),
(3, 'Dancho', '123'),
(4, 'babata', 'babata'),
(5, 'stoma', 'stoma'),
(6, 'Bukata', 'Bukata'),
(7, 'Kitka', 'Kitka'),
(8, 'mainata', 'mainata'),
(9, 'sopola', 'sopola'),
(10, 'minata', 'minata'),
(11, 'didi', '123'),
(12, 'sapun', 'sapun');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
