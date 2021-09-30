function plotIndices(scrambledIndices, correctIndices)
%{

Takes the scrambledIndices and the correctIndices as inputs and creates a
figure with two plots for comparison.

scrambledIndices: scrambled Indices
correctIndices: correct Indices
%}

fig = figure();
subplot(1,2,1);
scatter(linspace(1,size(correctIndices,2),size(correctIndices,2)), scrambledIndices);
title('Scrambled Indices');
axis([0 size(correctIndices,2), 0 size(correctIndices,2)]);
axis square;
xlabel('Player ID');
ylabel('Database Column');

subplot(1,2,2);
scatter(linspace(1,size(correctIndices,2),size(correctIndices,2)), correctIndices);
title('Correct Indices');
axis([0 size(correctIndices,2), 0 size(correctIndices,2)]);
axis square;
xlabel('Player ID');
ylabel('Database Column');

end