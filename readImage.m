function image = readImage(imgName)
%{

takes the path imgName as a string input and reads the image in that path.
If the input is a color image, the function converts it to grayscale and normalizes it. The
resulting image is assigned to the output variable image.

imgName: input image

image: normalized grayscale image

%}

image= imread(imgName);
if ndims(image)==3
    image = rgb2gray(image);
end
image = im2double(image);

end