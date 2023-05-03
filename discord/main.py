import discord
from discord.ext import commands
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

@bot.event
async def on_ready():
    
    print("Now we're cooking")
    
    # channels:
    general = bot.get_channel(1099948525892149280) #FIXME
    beep = bot.get_channel(1099960596943863818)

    # Init Message
    now = datetime.datetime.now()
    dt_string = now.strftime(f"%d/%m/%Y %H:%M:%S")
    await beep.send(f"\n \n ** Run time: {dt_string} * \n \n")
    
""" UPDATE COMMAND """
# 1. requests openCV data
# 2. Changes parking lot map to match open sports
# 3. send to discord channel

@bot.command()
async def update(ctx):
    
    func.draw_spaces(data, 'lib/images/parking_lot.png') # REPLACE DATA WITH NICK'S OUTPUT
    
    with open('space.png', 'rb') as f:
        picture = discord.File(f)
        await ctx.send("Engineering East Parking Lot: ", file=picture)
        await ctx.send("Blue = OPEN \nRed = CLOSED")
        
@bot.command()
async def talk(ctx):
    
    total_closed = 0
    for i in data:      # count total open
        if (not i):
            total_closed = total_closed + 1
    
    percentage_closed = int ( ( (total_closed) / (len(data)) ) * 100 )
    
    await ctx.send(f"Engineering West Parking Lot is {percentage_closed}% full", tts=True)

""" BOT KEY """
# key located in private folder

bot.run(key.botKey)