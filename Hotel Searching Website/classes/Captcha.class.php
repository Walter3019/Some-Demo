<?php

	header("Content-type: image/png");
	/**
	*  
	*/
	class Captcha
	{
		private $width;
		private $height;
		private $length;
		private $font;


		function __construct($width = 100, $height = 100, $length = 4, $font = 5)
		{
			$this->width = $width;
			$this->height = $height;
			$this->length = $length;
			$this->font = $font;
		}



		public function generate(){
			// 1. get image source.
			$im = imagecreatetruecolor($this->width, $this->height);

			// 2. random background image.
			$bg_color = imagecolorallocate($im, mt_rand(200,255), mt_rand(200,255), mt_rand(200,255));

			// 3 change background color.
			imagefill($im, 0, 0, $bg_color);

			// set five lines in captcha
			for ($i=0; $i < 4; $i++) { 
				$line_color = imagecolorallocate($im, mt_rand(50,100), mt_rand(50,100), mt_rand(50,100));
				imageline($im, mt_rand(0, $this->width), mt_rand(0, $this->height), mt_rand(0, $this->width), mt_rand(0, $this->height), $line_color);
			}

			// set pixels in captcha
			for ($i=0; $i < 200; $i++) { 
				$pixel_color = imagecolorallocate($im, mt_rand(100,150), mt_rand(100,150), mt_rand(100,150));
				imagesetpixel($im, mt_rand(0, $this->width), mt_rand(0, $this->height), $pixel_color);
			}

			// 4. get captcha string.
			$str = $this->getCaptchaString();

			// set captcha string color.
			$str_color = imagecolorallocate($im, mt_rand(0,50), mt_rand(0,50),mt_rand(0,50));

			// get captcha string start x and y
			$start_x = ceil($this->width / 2) - (ceil($this->width / 2) > 20 ? 20 : 5);
			$start_y = ceil($this->height / 2) - (ceil($this->height / 2) > 10 ? 10 : 5);

			imagestring($im, $this->font, $start_x, $start_y, $str, $str_color);

			//
			imagepng($im);

			// destroy image.
			imagedestroy($im);
		}




		private function getCaptchaString(){
			$str = "123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			$target = "";

			for ($i=0; $i < $this->length; $i++) { 
				$target .= $str[mt_rand(0, strlen($str) - 1)];
			}

			$_SESSION['captcha'] = $target;
			return $target;
		}





		public static function checkCaptcha($captcha){
			// 
			return (strtoupper($captcha) == strtoupper($_SESSION['captcha']));
		}

	}
?>