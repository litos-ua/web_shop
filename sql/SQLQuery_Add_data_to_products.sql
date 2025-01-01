USE InternetShopApiDb;
GO

INSERT INTO Products (Name, CategoryId, Price, Image, Description)
VALUES (
    'MK120.01',
    2,
    150,
    '/img/products/controllers/001.jpg',
    'PowerVoltage: 24V, ModBusChannel: 1, NumberOfDigitalInput: 16, NumberOfDigitalOutput: 32'
),
(
    'MK120.03',
    2,
    390,
    '/img/products/controllers/002.jpg',
    'TCPChannel: 1, PowerVoltage: 24V, ModBusChannel: 1, NumberOfAnalogInput: 2, NumberOfAnalogOutput: 8, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 16'
),
(
    'MK120.05',
    2,
    420,
    '/img/products/controllers/003.jpg',
    'PowerVoltage": 12V, ModBusChannel: 2, NumberOfAnalogInput: 1, NumberOfAnalogOutput: 4, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 8'
),
(
    'DVP20EX200T',
    2,
    790,
    '/img/products/controllers/004.jpg',
    'RS-232: 1, CANopen: master, Profibus: slave, TCPChannel: 1, PowerVoltage: 100~240V, ModBusChannel: 1, High-speed counters: 4, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 6, High-speed pulse output: 4 sets of 200kHz pulse output'
),
(
    'DVP12SE11T',
    2,
    590,
    '/img/products/controllers/005.jpg',
    'USB: Configurable USB-C port, RS-232: 1, PowerVoltage: 24V, NumberOfAnalogInput: 2, NumberOfAnalogOutput: 2, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 4'
),
(
    'DVP28SV11T',
    2,
    615,
    '/img/products/controllers/006.jpg',
    'RS-232: 1, "PowerVoltage: 100~240V, ModBusChannel: 2, NumberOfAnalogInput: 4, NumberOfAnalogOutput: 2, NumberOfDigitalInput: 16, NumberOfDigitalOutput: 12'
),
(
    'DVP14SS211T',
    2,
    620,
    '/img/products/controllers/007.jpg',
    'RS-232: 1, PowerVoltage: 100~240V, ModBusChannel: 2, High-speed counters: 1, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 6, High-speed pulse output: 4 sets of 200kHz pulse output'
),
(
    'DVP14SS212TX',
    2,
    670,
    '/img/products/controllers/008.jpg',
    'RS-232: 2, PowerVoltage: 100~240, ModBusChannel: 2, High-speed counters: 1, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 6, High-speed pulse output: 4 sets of 200kHz pulse output'
),
(
    'DVP14SS213TX',
    2,
    580,
    '/img/products/controllers/009.jpg',
    'PowerVoltage: 100~240V, ModBusChannel: 2, High-speed counters: 1, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 6, High-speed pulse output: 4 sets of 200kHz pulse output'
),
(
    'DVP14SS214TX',
    2,
    630,
    '/img/products/controllers/010.jpg',
    'RS-232: 1, PowerVoltage: 100~240V, ModBusChannel: 2, High-speed counters: 2, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 6, High-speed pulse output: 4 sets of 200kHz pulse output'
),
(
    'DVP14SS215TX',
    2,
    670,
    '/img/products/controllers/011.jpg',
    'RS-232: 2, PowerVoltage: 100~240V, ModBusChannel: 1, High-speed counters: 2, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 6, High-speed pulse output: 4 sets of 200kHz pulse output'
),
(
    'DVP14SS216TX',
    2,
    700,
    '/img/products/controllers/012.jpg',
    'RS-232: 2, PowerVoltage: 100~240V, ModBusChannel: 2, High-speed counters: 1, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 12, High-speed pulse output: 4 sets of 200kHz pulse output'
),
(
    'MT-121',
    2,
    750,
    '/img/products/compactmodules/001.jpg',
    'USB: Configurable USB-C port, GSM module: 2G/4G modem, TCPChannel: 1, PowerVoltage: 12/24V, ModBusChannel: 1, NumberOfAnalogInput: 3, NumberOfAnalogOutput: 1, NumberOfDigitalInput: 8, NumberOfDigitalOutput: 8'
),
(
    'MT-151',
    2,
    880,
    '/img/products/compactmodules/002.jpg',
    'USB: Configurable USB-C port, RS-232: 1, Display: OLED graphic display (128-64, GSM module: 2G/4G modem, TCPChannel: 1, PowerVoltage: 12/24V, ModBusChannel: 1, Battery Backup: Buffered power supply (SLA battery support), NumberOfAnalogInputs: 6, NumberOfAnalogOutput: 1, NumberOfDigitalInput: 16, Data and Event logger: SD card, NumberOfDigitalOutput: "12'
),
(
    'MT-156',
    2,
    630,
    '/img/products/compactmodules/003.jpg',
    'USB: Configurable USB-C port, RS-232: 1, TCPChannel: 1, PowerVoltage: 12/24V, ModBusChannel: 1, Battery Backup: Buffered power supply (SLA battery support), NumberOfAnalogInput: 2, "NumberOfDigitalInput: 10, Data and Event logger: SD card, NumberOfDigitalOutput: 12'
),
(
    'MT-161',
    2,
    670,
    '/img/products/compactmodules/004.jpg',
    'USB: Configurable USB-C port, RS-232: 1, Display: OLED graphic display (128-64), GSM module: 2G/4G modem, TCPChannel: 1, PowerVoltage: 12/24V, ModBusChannel: 1, Battery Backup: Buffered power supply (SLA battery support), NumberOfAnalogInput: 2, NumberOfDigitalInput: 4, Data and Event logger: SD card, NumberOfDigitalOutput: 12'
),
(
    'MT-171',
    2,
    710,
    '/img/products/compactmodules/005.jpg',
    'USB: Configurable USB-C port, TCPChannel: 1, PowerVoltage: 12/24V, ModBusChannel: 2, Battery Backup: Buffered power supply (SLA battery support), NumberOfAnalogInput: 4, NumberOfDigitalInput: 10, Data and Event logger: SD card, NumberOfDigitalOutput: 166'
),
(
    'MT-181',
    2,
    820,
    '/img/products/compactmodules/006.jpg',
    'USB: Configurable USB-C port, TCPChannel: 1, PowerVoltage: 12/24V, ModBusChannel: 1, "Battery Backup: Buffered power supply (SLA battery support), NumberOfAnalogInput: 4, NumberOfDigitalInput: 16, Data and Event logger: SD card, NumberOfDigitalOutput: 12'
),
(
    'MT-186',
    2,
    910,
    '/img/products/compactmodules/007.jpg',
    'USB: Configurable USB-C port, RS-232: 1, Display: OLED graphic display (128-64), GSM module: 2G/4G modem, TCPChannel: 1, PowerVoltage: 12/24V, ModBusChannel: 1, Battery Backup: Buffered power supply (SLA battery support), NumberOfAnalogInput: 2, NumberOfDigitalInput: 10, Data and Event logger: SD card, NumberOfDigitalOutput: 12'
);