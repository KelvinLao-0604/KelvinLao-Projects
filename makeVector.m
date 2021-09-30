function vecOut = makeVector(matrixIn)
%{
Takes a matrix as input and returns the vectorized version of this
matrix as output.

matrixIn: input matrix
vecOut: output vector

%}

num = isnumeric(matrixIn);
if num == true
    if ndims(matrixIn) <= 2
        vecOut = matrixIn(:);
    else
        error("Input matrix has more than 2 dimensions")
    end
else
    error("Input Matrix is not numeric")
end
end