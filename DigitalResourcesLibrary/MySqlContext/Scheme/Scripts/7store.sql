CREATE TABLE `store` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category` int(10) unsigned NOT NULL,
  `modified` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `visible` tinyint(1) DEFAULT NULL,
  `owner` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_store_category1_idx` (`category`),
  KEY `fk_store_user1_idx` (`owner`),
  CONSTRAINT `fk_store_category1` FOREIGN KEY (`category`) REFERENCES `category` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_store_user1` FOREIGN KEY (`owner`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
INSERT INTO `store` VALUES (5,3,'2013-12-17 13:51:35',1,1),(6,6,'2014-01-13 10:56:51',1,1),(7,6,'2013-12-17 08:52:44',1,1),(10,11,'2014-01-13 11:02:10',1,1),(11,11,'2014-01-13 11:02:37',1,1),(12,11,'2014-01-13 11:08:34',1,1),(13,11,'2014-01-13 11:08:16',1,1);


CREATE TABLE `storeloc` (
  `store` int(11) NOT NULL,
  `locale` int(11) NOT NULL,
  `data` mediumblob,
  `description` varchar(5000) CHARACTER SET utf8 DEFAULT NULL,
  `title` varchar(1000) CHARACTER SET utf8 DEFAULT NULL,
  `filename` varchar(500) CHARACTER SET utf8 DEFAULT NULL,
  `type` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`store`,`locale`),
  KEY `fk_storeloc_locale1_idx` (`locale`),
  CONSTRAINT `fk_storeloc_locale1` FOREIGN KEY (`locale`) REFERENCES `locale` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_storeloc_store1` FOREIGN KEY (`store`) REFERENCES `store` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;