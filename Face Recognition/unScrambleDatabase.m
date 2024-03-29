function [newDatabase,indices] = unScrambleDatabase(imagePath,database)
% UNSCRAMBLEDATABASE reorders the columns of the image database so each
% column corresponds to the correct player name
% 1 -> PlayerName1
% 2 -> PlayerName2
% 3 -> PlayerName3
% ...

% Inputs: 
%          imagePath   : Folder under which the images have been saved
%          database    : Image database
% Outputs:
%          newDatabase : Reordered database
%          indices     : indices for reordering

indices = zeros(1,size(database,2));
newDatabase = zeros(size(database));

% You have to write this part of code for this function to run properly
for ii = 1:(size(database,2))
playerImage = [imagePath, 'player', num2str(ii), '.png'];
image = readImage(playerImage);
min_error = findMinimumErrorPosition(image, database);
indices(1,ii) = min_error;
end


newDatabase = database(:,indices);
end