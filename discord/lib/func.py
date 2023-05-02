import cv2
#import pandas as pd

"""   MISC FUNCTIONS   """

def draw_spaces(array, path):
    
    image = cv2.imread(path)
    
    # TOP ROW
    for i in range(10):
        edit_top(image, i, array[i])
    
    # BOTTOM ROW
    for i in range(7):    
        j = i + 10          # array offset (to align with x_offset)
        edit_bot(image, i, array[j])   
    
    cv2.imwrite('space.png', image) # EXPORT AND SAVE IMAGE     

    # DEBUG
    # cv2.imshow("Wow", image)
    # cv2.waitKey(0)
    
def edit_top(image, index, is_open):
    
    """ RECTANGLE VARIABLES """
    left_x = 32
    right_x = 73
    red = (0, 0, 255)
    yellow = (0, 255, 255)
    blue = (255, 0, 0)
    thickness = 2
    
    if (is_open):
        color = blue
    else:
        color = red
    
    return cv2.rectangle(image, (left_x + (47 * index), 38), (right_x + (47 * index), 130), color, thickness)
    
def edit_bot(image, index, is_open):
    
    """ RECTANGLE VARIABLES """
    left_x = 170
    right_x = 211
    red = (0, 0, 255)
    yellow = (0, 255, 255)
    blue = (255, 0, 0)
    thickness = 2
    
    if (is_open):
        color = blue
    else:
        color = red
    
    return cv2.rectangle(image, (left_x + (47 * index), 410), (right_x + (47 * index), 502), color, thickness)

""" DEBUG MAIN """
