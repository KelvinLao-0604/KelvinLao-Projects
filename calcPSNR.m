function PSNR = calcPSNR(x1,x2,maxX)
%{

takes two column vectors (x1, x2) and a maximum value for their elements as
inputs and calculates their Peak Signal-to-Noise Ratio (PSNR) and assigns the
calculated value to the output variable PSNR.

x1: columun vector 1
x2: columun vector 2
maxX: maximum value for x1 and x2

PSNR: Peak Signal-to-Noise Ratio
%}

if ~exist('maxX','var') || isempty(limits)
    maxX = 1;
end

MSE = calcMSE(x1,x2);
if MSE == 0
    PSNR = 100;
else
    PSNR = 10 * log10(maxX^2/MSE);
end

end