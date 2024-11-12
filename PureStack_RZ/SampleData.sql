-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: forum
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `answers`
--

DROP TABLE IF EXISTS `answers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answers` (
  `answer_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `question_id` int NOT NULL,
  `content` varchar(5600) NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`answer_id`),
  KEY `question_id_idx` (`question_id`),
  KEY `user_id_idx` (`user_id`),
  CONSTRAINT `question_id_fk1` FOREIGN KEY (`question_id`) REFERENCES `questions` (`question_id`),
  CONSTRAINT `user_id_fk2` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `answers`
--

LOCK TABLES `answers` WRITE;
/*!40000 ALTER TABLE `answers` DISABLE KEYS */;
INSERT INTO `answers` VALUES (1,5,4,'Who cares? Try lobsters, they\'ll make you forget about your visual studio!','2021-04-04 15:24:45'),(2,5,2,'Try feeding him lobsters or giving him lobster pets','2021-04-04 15:25:07'),(3,4,5,'INGREDIENTS\r\n1/4 c. mayonnaise\r\n1 stalk celery, finely diced\r\n2 tbsp. lemon juice\r\n2 tbsp. finely chopped chives, plus more for serving\r\nKosher salt\r\n3 (12-oz.) lobster tails, steamed, meat removed and chopped (3 c.)\r\nButterhead lettuce, for serving\r\nSliced avocado, for serving\r\nLemon wedges, for serving\r\nThis ingredient shopping module is created and maintained by a third party, and imported onto this page. You may be able to find more information about this and similar content on their web site.\r\n \r\nDIRECTIONS\r\nIn a bowl, stir together mayonnaise, celery, lemon juice, and chives. Season with salt. Fold in chopped lobster meat.\r\nLay lettuce on a serving platter, then top with lobster salad. Garnish with avocado, more chives, and a squeeze of lemon.','2021-04-04 15:26:41'),(5,4,1,'Let’s look at why we learn math, and then which of those whys is actually taught.\r\n\r\nWe should learn math because:\r\n\r\n(1) It is a useful tool\r\n\r\n(2) It helps us to think\r\n\r\n(3) It is beautiful\r\n\r\nNow, how does our schooling meet these reasons?\r\n\r\n(1) A useful tool. We are told often “you will need this someday”. “When?” we ask. Then we are given reasons like:\r\n\r\na. When you need to compare telephone plans. (Weak. These kind of uses need the bare minimum math skills, even if you can write a system of equations and a graph to compare plans, you don’t need to).\r\n\r\nb. If you want to become an engineer you’ll need this. (OK, that’s fine for the tiny percentage of people who will become an engineer. The truth is a very small fraction of people will ever need more than a very small fraction of math that is taught in schools.)\r\n\r\nc. Without math, your computer would never work! (OK, but that really doesn’t mean I have to learn the math behind technology. It works fine without me knowing a thing about binary.)\r\n\r\nd. You’ll need it later. If you want to do university math you’ll need to know this. (Uff. See (b).)\r\n\r\ne. You’ll need it soon, for the next test. (OK, at least this can be motivating! The real reason I need to learn math is because I’m going to be tested on it and get a grade that will affect my life.)\r\n\r\nFact: mathematical thinking affects every decision you make and the way you look at and make sense of the world. Visualising, problem-solving, mental arithmetic, geometric thinking, thinking in terms of ratios, spatial reasoning… we use this constantly and if you’re good at thinking flexibly you’ll be good at a lot of things. HOWEVER, school barely touches on these kinds of thinking.\r\n\r\n2. It helps us think. But how? If taught properly, absolutely. Things like seeing connections, thinking about how shapes and numbers fit together and being able to translate from one kind of representation to another, mentally or with a sketch or with a model, seeing many ways to approach a problem and selecting one or several methods to try and being able to evaluate the strengths and weaknesses of all these. Priceless! HOWEVER, school teaches math as something to be memorized without connections or even really thinking, and instead school math teaches us NOT TO THINK.\r\n\r\n3. It is beautiful. People say this, and those who say it actually mean it. There is beauty in patterns and geometry, and the way ideas fit together and surprising connections and elegant proofs. There are pictures and structures and IDEAS in mathematics that can take your breath away and make you marvel at the universe and burn with a desire to see and learn more! You know what? Most don’t understand this. Most never see this. Most don’t get it. Math is a set of scribbly numbers and symbols on paper that is not beautiful at all. And that’s thanks to school.\r\n\r\nSo what do we have? Most of the reasons we’re told we need math are LIES. The real reasons, the really important reasons, aren’t taught in school.\r\n\r\nWhy is that? I blame testing, mostly. A kid learns to connect ideas and do some original thinking that creates something beautiful and useful. Awesome! How do we test that on a multiple choice standardized test? You can’t. The only things you can test are the most trivial banal useless bits of mathematics. And if that’s what’s on the test, that’s what gets taught.\r\n\r\nThere is no easy answer to this question. We need inspired teachers who dare to teach thinking and bring out the mathematics in art, music, games and crafts. Teachers who can present fun and fantastic puzzles that kids love to do and bring out the mathematical structures and let the kids play with them.\r\n\r\nKids with this kind of learning do just fine on standardized tests, even for problems they haven’t seen copies of and memorized methods. They are capable of understanding unfamiliar mathematical situations and coming up with solutions on the spot.\r\n\r\nWe need a societal reset on what mathematics is, what is important, and how the best way to teach the important parts is. It’s not by memorizing. It’s by playing and daring to take risks, propose ideas and defend them, make connections, solve interesting problems, and CREATE with mathematics.','2021-04-04 15:31:36'),(6,1,3,'no u r tupid !!','2021-04-04 15:36:18'),(7,1,5,'i don\'t like lobter','2021-04-04 15:36:31');
/*!40000 ALTER TABLE `answers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `category_id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(45) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Myths');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `question_categories`
--

DROP TABLE IF EXISTS `question_categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `question_categories` (
  `question_id` int NOT NULL,
  `category_id` int NOT NULL,
  PRIMARY KEY (`question_id`,`category_id`),
  KEY `category_id_fk_cat_idx` (`category_id`),
  CONSTRAINT `category_id_fk_cat` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`),
  CONSTRAINT `question_id_fk_cat` FOREIGN KEY (`question_id`) REFERENCES `questions` (`question_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question_categories`
--

LOCK TABLES `question_categories` WRITE;
/*!40000 ALTER TABLE `question_categories` DISABLE KEYS */;
/*!40000 ALTER TABLE `question_categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `question_id` int NOT NULL AUTO_INCREMENT,
  `contents` varchar(5600) NOT NULL,
  `header` varchar(100) NOT NULL,
  `user_id` int NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`question_id`),
  KEY `user_id_fk1_idx` (`user_id`),
  CONSTRAINT `user_id_fk1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
INSERT INTO `questions` VALUES (1,'I was in math class and I fell asleep. I don\'t understand why math is so boring, it\'s supposed to be fun and interesting but I just can\'t seem to enjoy it. What should I do?','Why is math so boring?',1,'2021-04-04 15:17:47'),(2,'How can you help? Everything I do and he only plays Minecraft why does he play minecraft all day!??!!?','My son doesn\'t want to study',2,'2021-04-04 15:18:56'),(3,'How can I give him more knowledge??? I go to him and I try to teach him how to smart, but I am not enough smart?','My brother is dumb?',3,'2021-04-04 15:20:27'),(4,'I was wondering when is the next VS coming out? I\'m using VS 2013 and it is getting on my nerves with bugs and missing features. Please, if you have an answer, let me know!','When is the next visual studio coming out?',4,'2021-04-04 15:22:14'),(5,'I really love lobsters, like, really really like lobsters. I mean they\'re the best meat/pets/both that I\'ve ever had and I want to try a newer, more tastier recipe. Also, please make sure it\'s real lobsters because I love lobsters. \r\nJohn the Lobter.','What is the best lobster recipe?',5,'2021-04-04 15:23:51'),(6,'Can I just catch the exception and then throw new Exception?','Should I define my own exception class?',4,'2021-04-04 15:33:36'),(7,'Just wondering','Why is the earth round?',4,'2021-04-04 15:34:00');
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `picture` varchar(500) DEFAULT NULL,
  `admin` bit(1) DEFAULT b'0',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  UNIQUE KEY `name_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Tohar','tohar77@hotmail.com','nopassword','1743_pubgpan.png',_binary ''),(2,'Oleg','oananiev@gmail.com','abcd10569','download (1).png',_binary '\0'),(3,'Izhar','izhar_ananiev@hotmail.com','karen123','squedwerd.gif',_binary '\0'),(4,'Josh','josh@rogozin.ort.org.il','rahavisntwhatsheseems','GRW_skull_1920x1080.jpg',_binary '\0'),(5,'John the Lobster','ilovelobster@gmail.com','lobterdopter','image1-3.jpg',_binary '\0');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `votes`
--

DROP TABLE IF EXISTS `votes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `votes` (
  `thread_id` int NOT NULL,
  `user_id` int NOT NULL,
  `is_question` bit(1) NOT NULL,
  `good_bad` bit(1) DEFAULT NULL,
  PRIMARY KEY (`thread_id`,`user_id`,`is_question`),
  KEY `user_id_vote_idx` (`user_id`),
  CONSTRAINT `user_id_vote` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `votes`
--

LOCK TABLES `votes` WRITE;
/*!40000 ALTER TABLE `votes` DISABLE KEYS */;
INSERT INTO `votes` VALUES (1,4,_binary '',_binary ''),(1,5,_binary '',_binary ''),(3,1,_binary '\0',_binary ''),(3,1,_binary '',_binary '\0'),(3,5,_binary '\0',_binary ''),(4,1,_binary '',_binary ''),(4,3,_binary '',_binary ''),(4,4,_binary '',_binary ''),(4,5,_binary '',_binary '\0'),(5,1,_binary '\0',_binary ''),(5,4,_binary '',_binary ''),(6,1,_binary '',_binary ''),(6,3,_binary '',_binary ''),(7,1,_binary '\0',_binary ''),(7,1,_binary '',_binary ''),(7,3,_binary '',_binary '\0');
/*!40000 ALTER TABLE `votes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `weights`
--

DROP TABLE IF EXISTS `weights`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `weights` (
  `id` int NOT NULL,
  `question_good` int NOT NULL,
  `question_bad` int NOT NULL,
  `answer_good` int NOT NULL,
  `answer_bad` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `weights`
--

LOCK TABLES `weights` WRITE;
/*!40000 ALTER TABLE `weights` DISABLE KEYS */;
INSERT INTO `weights` VALUES (1,1,1,1,1);
/*!40000 ALTER TABLE `weights` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-04-04 15:38:30
