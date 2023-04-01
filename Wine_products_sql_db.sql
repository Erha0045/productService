-- -----------------------------------------------------
-- Schema WineProductDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `WineProductDB` DEFAULT CHARACTER SET utf8 ;
USE `WineProductDB`;

-- -----------------------------------------------------
-- Table `WineProductDB`.`wine_categories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `WineProductDB`.`wine_categories` (
  `category_id` INT UNIQUE NOT NULL,
  `category_name` VARCHAR(100) UNIQUE NOT NULL,
  PRIMARY KEY (`category_id`));

-- -----------------------------------------------------
-- Table `WineProductDB`.`wine_products`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `WineProductDB`.`wine_products` (
  `wine_id` INT UNIQUE NOT NULL,
  `wine_name` VARCHAR(255) NOT NULL,
  `image` VARCHAR(255) NOT NULL,
  `price` FLOAT NOT NULL,
  `production_year` INT NOT NULL,
  `bottle_size` VARCHAR(10) NOT NULL,
  `alcohol_percentage` FLOAT NOT NULL,
  `wine_origin` VARCHAR(500) NOT NULL,
  `wine_description` VARCHAR(500) NOT NULL,
  `wine_category_id` INT NOT NULL,
  PRIMARY KEY (`wine_id`),
  INDEX `fk_wine_products_wine_categories_idx` (`wine_category_id` ASC) VISIBLE,
  CONSTRAINT `fk_wine_products_wine_categories`
    FOREIGN KEY (`wine_category_id`)
    REFERENCES `WineProductDB`.`wine_categories` (`category_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- Inserting data into WineProductDB.wine_categories
INSERT INTO WineProductDB.wine_categories (category_id, category_name) VALUES
(1, 'Red wine'),
(2, 'White wine'),
(3, 'Rosé Wine'),
(4, 'Sparkling Wine'),
(5, 'Dessert Wine'),
(6, 'Organic Wine');

-- Inserting data into WineProductDB.wine_products
INSERT INTO WineProductDB.wine_products (wine_id, wine_name, image, price, production_year, bottle_size, alcohol_percentage, wine_origin, wine_description, wine_category_id) VALUES
(1, 'Cabernet Sauvignon', 'TBD', 25.99, 2016, '750ml', 13.5, 'Napa Valley, California', 'Full-bodied with dark fruit flavors and a hint of vanilla', 1),
(2, 'Chardonnay', 'TBD',19.99, 2018, '750ml', 12.5, 'Sonoma Coast, California', 'Rich and creamy with notes of tropical fruit and oak', 2),
(3, 'Provence Rosé', 'TBD',14.99, 2020, '750ml', 12, 'Provence, France', 'Dry and crisp with flavors of strawberry and melon', 3),
(4, 'Champagne Brut', 'TBD',39.99, 2019, '750ml', 12, 'Champagne, France', 'Dry and bubbly with notes of green apple and citrus', 4),
(5, 'Late Harvest Riesling','TBD', 29.99, 2015, '375ml', 10, 'Columbia Valley, Washington', 'Sweet and floral with flavors of apricot and honey', 5),
(6, 'Pinot Grigio', 'TBD',17.99, 2019, '750ml', 12, 'Veneto, Italy', 'Light-bodied with crisp acidity and notes of citrus and pear', 2),
(7, 'Cabernet Franc', 'TBD', 32.99, 2017, '750ml', 13.5, 'Finger Lakes, New York', 'Medium-bodied with flavors of red fruit and black pepper', 1),
(8, 'Cava Brut', 'TBD' ,22.99, 2021, '750ml', 11.5, 'Penedès, Spain', 'Dry and refreshing with flavors of green apple and toast', 4),
(9, 'Sauternes','TBD',45.99, 2014, '375ml', 14, 'Bordeaux, France', 'Sweet and complex with flavors of honey and apricot', 5),
(10, 'Pinot Noir', 'TBD',29.99, 2018, '750ml', 13, 'Willamette Valley, Oregon', 'Light to medium-bodied with flavors of red fruit and earth', 1),
(11, 'Moscato', 'TBD', 12.99, 2018,'750ml', 5.5, 'Piedmont, Italy', 'Sweet and effervescent with flavors of peach and orange blossom', 5),
(12, 'Côtes du Rhône Blanc', 'TBD' ,21.99, 2020, '750ml', 13, 'Rhône Valley, France', 'Medium-bodied with flavors of stone fruit and herbs', 2);