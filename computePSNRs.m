function PSNRs = computePSNRs(imgVec, imageDatabase)
%{
Takes a vectorized image (imgVec) and a database matrix of vectorized images
(imageDatabase) as inputs and computes the PSNR between imgVec and each image (col-
umn) in the database matrix. The calculated PSNRs for all images in the database should
be stored in an array of correct size and assigned to the output variable PSNRs.

imgVec: vectorized image
imageDatabase: database matrix of vectorized images

PSNRs:row vector with the number of rows of imgVec as the number of columns

%}
n = size(imageDatabase,2);
PSNRs = zeros(1,n);
for ii = 1:n
    PSNRs(1,ii) = calcPSNR(imgVec, imageDatabase(:,ii));
end
end