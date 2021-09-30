function minPos = findMinimumErrorPosition(imgVec, imageDatabase)
%{

takes a vectorized image (imgVec) and a database matrix of vectorized images
(imageDatabase) as inputs and nds the position (column index) of the vectorized image
in the database matrix that produces the smallest MSE with the input imgVec. The result
(column index) is assigned to the output minPos.

imgVec: vectorized image
imageDatabase: database matrix of vectorized images

minPos:position of the vectorized image in the database matrix that produces the smallest MSE

%}
n = size(imageDatabase,2);
pos = zeros(1,n);
for ii = 1:n
    pos(1,ii) = calcMSE(imgVec, imageDatabase(:,ii));
end
x = min(pos);
minPos = find(pos == x);
end