function MSE = calcMSE(x1,x2)
%{
Takes two column vectors (x1, x2) as inputs, calculates their Mean Squared Error
and assigns the result to the output variable MSE

x1: columun vector 1
x2: columun vector 2

MSE: Mean Squared Error

%}

x1 = makeVector(x1);
x2 = makeVector(x2);
m = size(x1,1);
MSE = 0;
for ii = 1:m
    MSE = MSE + (x1(ii,1)-x2(ii,1))^2;
end
MSE = (1/m) * MSE;
end