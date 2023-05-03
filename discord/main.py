import discord
from discord.ext import commands
from discord.ext import tasks
import datetime
from hidden import key
from lib import func
import time

print('running')

# Client
intents = discord.Intents.default()
intents.members = True
intents.presences = True
intents.message_content = True
bot = commands.Bot(command_prefix = '!', intents = intents)

""" Global vars """

data = [False, False, False, False, True, True, True, False, False, False, True, True, True, True, False, True, True] # FIXME
bot_channel = 1099960596943863818
general_channel = 1099948525892149280
park_channel = 1103156024967434350

parking_lot_name = "Engineering West Parking Lot"

"""

    BOT EVENTS

"""

@bot.event
async def on_ready():
    
    print("Now we're cooking")
    
    # change status
    await bot.change_presence(activity = discord.Activity(type = discord.ActivityType.watching, name = parking_lot_name))
    
    # channels:
    general = bot.get_channel(general_channel) #FIXME
    beep = bot.get_channel(bot_channel)

    # Init Message DEBUG
    now = datetime.datetime.now()
    dt_string = now.strftime(f"%d/%m/%Y %H:%M:%S")
    await beep.send(f"\n \n ** Run time: {dt_string} * \n \n")
    
    # START LOOPS
    
    await mainLoop.start()
    
"""

    COMMANDS!!!

"""
# 1. requests openCV data
# 2. Changes parking lot map to match open sports
# 3. send to discord channel

@bot.command()
async def update(ctx):
<<<<<<< HEAD
    await ctx.send("Yay, daddy! This is the main function :P")
=======
    
    func.draw_spaces(data, 'lib/images/parking_lot.png') # REPLACE DATA WITH NICK'S OUTPUT
    
    with open('space.png', 'rb') as f:
        picture = discord.File(f)
        await ctx.send("Engineering East Parking Lot: ", file=picture)
        await ctx.send("Blue = OPEN                 Red = CLOSED")
        
    total_closed = 0
    for i in data:      # count total open
        if (not i):
            total_closed = total_closed + 1
    
    percentage_closed = int ( ( (total_closed) / (len(data)) ) * 100 )
    
    await ctx.send(f"Engineering West Parking Lot is {percentage_closed}% full", tts=True)
        
"""
@bot.command()
async def talk(ctx):
    
    total_closed = 0
    for i in data:      # count total open
        if (not i):
            total_closed = total_closed + 1
    
    percentage_closed = int ( ( (total_closed) / (len(data)) ) * 100 )
    
    await ctx.send(f"Engineering West Parking Lot is {percentage_closed}% full", tts=True)
"""

"""

    PROCEDURALLY RUN TASKS

"""

@tasks.loop(seconds=60)
async def mainLoop():
    
    park = bot.get_channel(park_channel)
    
    # Send image
    
    func.draw_spaces(data, 'lib/images/parking_lot.png') # REPLACE DATA WITH NICK'S OUTPUT
    
    # Delete previous messages
    await park.purge(limit=10)
    
    with open('space.png', 'rb') as f:
        picture = discord.File(f)
        await park.send("Engineering East Parking Lot: ", file=picture)
        await park.send("Blue = OPEN                 Red = CLOSED")
        
    total_closed = 0
    for i in data:      # count total open
        if (not i):
            total_closed = total_closed + 1
    
    percentage_closed = int ( ( (total_closed) / (len(data)) ) * 100 )
    
    
    await park.send(f"Engineering West Parking Lot is {percentage_closed}% full", tts=True)
>>>>>>> 66a67c3e171009957cfc0cdc53d724f1bef29bf2

""" BOT KEY """
# key located in private folder

bot.run(key.botKey)