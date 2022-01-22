CREATE TABLE IF NOT EXISTS `movie` (
  `id` INT(10) NOT NULL AUTO_INCREMENT,
  `author` LONGTEXT NULL,
  `launch_date` DATETIME NULL,
  `release_date` DATETIME NULL,
  `rating` DECIMAL(65,2) NULL,
  `title` LONGTEXT NULL,
  `comparision` LONGTEXT NULL,
  `keywords` LONGTEXT NULL,
  `source` LONGTEXT NULL,
  `genre` LONGTEXT NULL,
  `production` LONGTEXT NULL,
  `production_type` LONGTEXT NULL,
  `production_countries` LONGTEXT NULL,
  `language` LONGTEXT NULL,
    `cast` LONGTEXT NULL,
  `synopsis` LONGTEXT NULL,
  `reviwes` LONGTEXT NULL,
   PRIMARY KEY (`id`));


