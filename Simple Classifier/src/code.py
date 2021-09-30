import common


def part_one_classifier(data_train, data_test):
	# Access the training data using "data_train[i][j]"
	# Training data contains 3 cols per row: X in 
	# index 0, Y in index 1 and Class in index 2
	# Access the test data using "data_test[i][j]"
	# Test data contains 2 cols per row: X in 
	# index 0 and Y in index 1, and a blank space in index 2 
	# to be filled with class
	# The class value could be a 0 or a 1
	def classified (temp_data, train_data):
		for i in range(common.constants.TRAINING_SIZE):
			if temp_data[i][2] != train_data[i][2]:
				return False
		return True
	def classify (datax, datay, weights):
		f = [1, datax, datay]
		c = (f[0] * weights[0]) + (f[1] * weights[1]) + (f[2] * weights[2])
		if c >= 0:
			return 1
		else:
			return 0

	weights = [0, 0, 0]  # bias, x, y
	training_data = [[0, 0, 10] for x in range(common.constants.TRAINING_SIZE)]
	while not classified(training_data, data_train):
		for i in range(common.constants.TRAINING_SIZE):
			c = classify(data_train[i][0], data_train[i][1], weights)
			t = data_train[i][2] #class for current point
			training_data[i][2] = c
			if c != t:
				if c == 1:
					weights[0] -= 1
					weights[1] -= data_train[i][0]
					weights[2] -= data_train[i][1]
				else:
					weights[0] += 1
					weights[1] += data_train[i][0]
					weights[2] += data_train[i][1]
	for i in range(common.constants.TEST_SIZE):
		data_test[i][2] = classify(data_test[i][0], data_test[i][1], weights)
	return


def part_two_classifier(data_train, data_test):
	# Access the training data using "data_train[i][j]"
	# Training data contains 3 cols per row: X in 
	# index 0, Y in index 1 and Class in index 2
	# Access the test data using "data_test[i][j]"
	# Test data contains 2 cols per row: X in 
	# index 0 and Y in index 1, and a blank space in index 2 
	# to be filled with class
	# The class value could be a 0 or a 8
	def classified(temp_data, train_data):
		for i in range(common.constants.TRAINING_SIZE):
			if temp_data[i] != train_data[i][2]:
				return False
		return True

	def classify(datax, datay, weights):
		f = [1, datax, datay]
		wmax = -100
		max_score = -100
		for i in range(10):
			score = (f[0] * weights[i][0]) + (f[1] * weights[i][1]) + (f[2] * weights[i][2])
			if score > max_score:
				max_score = score
				wmax = i
		return int(wmax)

	weights = [[0, 0, 0] for x in range(common.constants.NUM_CLASSES)]  # bias, x, y
	training_data = [100 for x in range(common.constants.TRAINING_SIZE)]
	while not classified(training_data, data_train):
		for i in range(common.constants.TRAINING_SIZE):
			c = classify(data_train[i][0], data_train[i][1], weights)
			t = int(data_train[i][2])# class for current point
			training_data[i] = c
			if c != t:
				weights[c][0] -= 1
				weights[c][1] -= data_train[i][0]
				weights[c][2] -= data_train[i][1]
				weights[t][0] += 1
				weights[t][1] += data_train[i][0]
				weights[t][2] += data_train[i][1]
	for i in range(common.constants.TEST_SIZE):
		data_test[i][2] = classify(data_test[i][0], data_test[i][1], weights)
	return
