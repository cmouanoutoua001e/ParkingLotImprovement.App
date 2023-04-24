import discord  as d
from discord.ext import commands
import asyncio
import datetime
from hidden import key

print('running')

# Client
intents = d.Intents.default()
intents.members = True
intents.presences = True
bot = commands.Bot(command_prefix = '!', intents = intents)

@bot.event
async def on_ready(ctx):
    
    print("Now we're cooking")

    # Init Message
    now = datetime.now()
    dt_string = now.strftime(f"%d/%m/%Y %H:%M:%S")
    await ctx.send(f"\n \n ** Run time: {dt_string} * \n \n")

""" BOT KEY """
# key located in private folder

bot.run(key.botKey)